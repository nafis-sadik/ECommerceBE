using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IActionResult LogIn(string userId, string password)
        {
            if (_logIn.UserLogIn(userId, password, out string resMsg))
                return Ok("JWT Token");
            else
                return Conflict(resMsg);
        }
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(string UserName, string PhoneNumber, int UserTypeId, string ProfilePicLoc, string Password)
        {
            if (_logIn.UserRegister(new Entities.User {
                UserName = UserName,
                Password = Password,
                PhoneNumber = PhoneNumber,
                UserTypeId = UserTypeId,
                ProfilePicLoc = ProfilePicLoc
            }))
                return Ok("JWT Token");
            else
                return Conflict("Operation Failed");
        }
    }
}
