using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IUserServices
    {
        bool UserLogIn(string UserName, string Password, out string errMsg);
        bool UserRegister(User user);
    }
}
