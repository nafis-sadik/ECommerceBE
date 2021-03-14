using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class CommonCode
    {
        public CommonCode()
        {
            InventoryLogs = new HashSet<InventoryLog>();
            Users = new HashSet<User>();
        }

        public decimal CommonCodeId { get; set; }
        public string TableName { get; set; }
        public string NameEnglish { get; set; }
        public string NameBangla { get; set; }

        public virtual ICollection<InventoryLog> InventoryLogs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
