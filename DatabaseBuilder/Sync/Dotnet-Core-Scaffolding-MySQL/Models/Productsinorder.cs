using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Productsinorder
    {
        public decimal Pk { get; set; }
        public decimal OrderId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Shopproduct PkNavigation { get; set; }
    }
}
