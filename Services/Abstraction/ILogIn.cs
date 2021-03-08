using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface ILogIn
    {
        bool UserLogIn(string UserName, string Password);
    }
}
