using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Shop
    {
        public Shop()
        {
            Categories = new HashSet<Category>();
            ShopProducts = new HashSet<ShopProduct>();
            Vendors = new HashSet<Vendor>();
        }

        public decimal ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopLogoLocation { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ShopProduct> ShopProducts { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
