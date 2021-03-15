using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IUserServices
    {
        bool UserLogIn(string UserName, string Password, out string strResponse);
        bool UserRegister(User user, out string strResponse);
        bool UpdateProfile(User userData, out string strResponse);
    }
}
