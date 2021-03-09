using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogIn _logIn;
        public LogInController(ILogIn logIn)
        {
            _logIn = logIn;
        }

        public IActionResult LogIn(string userId, string password)
        {
            _logIn.UserLogIn(userId, password);
            throw new NotImplementedException();
        }
    }
}
