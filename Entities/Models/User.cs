using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? UserTypeId { get; set; }
        public string ProfilePicLoc { get; set; }

        public virtual CommonCode UserType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
