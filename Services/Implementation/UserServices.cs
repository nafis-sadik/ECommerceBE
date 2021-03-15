using DevOne.Security.Cryptography.BCrypt;
using Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
//using System.Security.Cryptography;

namespace Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepo;
        //private HashAlgorithm algorithm = new SHA256Managed();
        private string salt = "Hakuna Matata";
        public UserServices()
        {
            _userRepo = new UserRepo();
        }

        private string GenerateJwtToken(string userName)
        {
            JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] tokenKey = Encoding.ASCII.GetBytes(userName);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, userName)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = JwtTokenHandler.CreateToken(tokenDescriptor);
            return JwtTokenHandler.WriteToken(securityToken);
        }

        public bool UserLogIn(string UserName, string Password, out string strResponse)
        {
            strResponse = "";
            var user = _userRepo.AsQueryable().FirstOrDefault(x => x.UserName == UserName);
            if (user != null)
            {
                bool passwordMatched = BCryptHelper.CheckPassword(Password, user.Password);
                if (!passwordMatched)
                    strResponse = "Password mismatched";
                else
                    strResponse = GenerateJwtToken(UserName);
                byte[] token = KeyDerivation.Pbkdf2(UserName, Encoding.Default.GetBytes(salt), KeyDerivationPrf.HMACSHA1, 1000, 256);
                return passwordMatched;
            }
            else
            {
                strResponse = "User not found";
                return false;
            }
        }

        public bool UserRegister(User newUser, out string strResponse)
        {
            try{
                newUser.Password = BCryptHelper.HashPassword(newUser.Password, BCryptHelper.GenerateSalt(12));
                int maxUID = (int)_userRepo.AsQueryable().Max(x => x.UserId);
                newUser.UserId = maxUID + 1;
                _userRepo.Add(newUser);
                _userRepo.Save();
                strResponse = GenerateJwtToken(newUser.UserName);
                return true;
            }catch(Exception ex){
                if (ex.InnerException == null)
                    strResponse = ex.Message;
                else
                    strResponse = ex.InnerException.Message;
                return false;
            }
        }

        public bool UpdateProfile(User userData, out string strResponse)
        {
            try
            {
                strResponse = "Success";
                User oldData = _userRepo.Get(x => x.UserId == userData.UserId);
                oldData.UserName = userData.UserName;
                oldData.UserType = userData.UserType;
                oldData.Password = BCryptHelper.HashPassword(userData.Password, salt);
                oldData.ProfilePicLoc = userData.ProfilePicLoc;
                oldData.UserTypeId = userData.UserTypeId;
                _userRepo.Update(oldData);
                strResponse = GenerateJwtToken(oldData.UserName);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    strResponse = ex.Message;
                else
                    strResponse = ex.InnerException.Message;
                return false;
            }
        }
    }
}
