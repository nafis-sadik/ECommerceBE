using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Shopproduct
    {
        public Shopproduct()
        {
            Productreturns = new HashSet<Productreturn>();
        }

        public decimal Pk { get; set; }
        public decimal ProductId { get; set; }
        public decimal SubCategoryId { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public decimal? Stock { get; set; }
        public decimal? ShopId { get; set; }
        public decimal? VendorId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual Subcategory SubCategory { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual Inventorylog Inventorylog { get; set; }
        public virtual ICollection<Productreturn> Productreturns { get; set; }
    }
}
