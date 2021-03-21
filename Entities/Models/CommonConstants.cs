using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public static class CommonConstants
    {
        public static string Salt { 
            get {
                return "Keno Megh Ashe, Hridoyo Akash, Tomaye Dekhite Dei Na";
            } 
            private set { }
        }
        public static int StandardPageSize
        {
            get { return 20; }
            private set { }
        }
    }
}
