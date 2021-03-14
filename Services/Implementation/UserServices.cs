using DevOne.Security.Cryptography.BCrypt;
using Entities;
using Repositories;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool UserLogIn(string UserName, string Password, out string errMsg)
        {
            errMsg = "";
            var user = _userRepo.AsQueryable().FirstOrDefault(x => x.UserName == UserName);
            if (user != null)
            {
                bool passwordMatched = BCryptHelper.CheckPassword(Password, user.Password);
                if (!passwordMatched)
                    errMsg = "Password mismatched";
                else
                    errMsg = "Success";
                return passwordMatched;
            }
            else
            {
                errMsg = "User not found";
                return false;
            }
        }

        public bool UserRegister(User newUser)
        {
            try{
                newUser.Password = BCryptHelper.HashPassword(newUser.Password, BCryptHelper.GenerateSalt(12));
                int maxUID = (int)_userRepo.AsQueryable().Max(x => x.UserId);
                newUser.UserId = maxUID + 1;
                _userRepo.Add(newUser);
                _userRepo.Save();
                return true;
            }catch(Exception ex){
                return false;
            }
        }

        public bool UpdateProfile(User userData)
        {
            try
            {
                var oldData = _userRepo.Get(x => x.UserId == userData.UserId);
                oldData.UserName = userData.UserName;
                oldData.UserType = userData.UserType;
                oldData.Password = BCryptHelper.HashPassword(userData.Password, salt);
                oldData.ProfilePicLoc = userData.ProfilePicLoc;
                oldData.UserTypeId = userData.UserTypeId;
                _userRepo.Update(oldData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
