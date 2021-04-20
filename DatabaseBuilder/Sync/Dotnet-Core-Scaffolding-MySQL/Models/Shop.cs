using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Categories = new HashSet<Category>();
            Shopproducts = new HashSet<Shopproduct>();
            Vendors = new HashSet<Vendor>();
        }

        public decimal ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopLogoLocation { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Shopproduct> Shopproducts { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
