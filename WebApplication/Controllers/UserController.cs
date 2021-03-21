using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Abstraction;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _logIn;
        public UserController()
        {
            _logIn = new UserServices();
        }
        [HttpPost]
        [Route("LogIn/{userId}/{password}")]
        [AllowAnonymous]
        public IActionResult LogIn(string userId, string password)
        {
            if (_logIn.UserLogIn(userId, password, out string resMsg))
            {
                return Ok(resMsg);
            }
            else
                return Conflict(resMsg);
        }
        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public IActionResult SignUp(string UserName, string PhoneNumber, int UserTypeId, string ProfilePicLoc, string Password)
        {
            if (_logIn.UserRegister(new User
            {
                UserName = UserName,
                Password = Password,
                PhoneNumber = PhoneNumber,
                UserTypeId = UserTypeId,
                ProfilePicLoc = ProfilePicLoc
            }, out string strResponse))
                return Ok(strResponse);
            else
                return Conflict(strResponse);
        }
    }
}
