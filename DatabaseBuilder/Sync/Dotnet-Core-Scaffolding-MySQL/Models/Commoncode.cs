using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Commoncode
    {
        public Commoncode()
        {
            Inventorylogs = new HashSet<Inventorylog>();
            Users = new HashSet<User>();
        }

        public decimal CommonCodeId { get; set; }
        public string TableName { get; set; }
        public string NameEnglish { get; set; }
        public string NameBangla { get; set; }

        public virtual ICollection<Inventorylog> Inventorylogs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
