using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class ShopProduct
    {
        public ShopProduct()
        {
            ProductReturns = new HashSet<ProductReturn>();
        }

        public decimal ProductId { get; set; }
        public decimal SubCategoryId { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal Pk { get; set; }
        public string ProductDescription { get; set; }
        public decimal? Stock { get; set; }
        public decimal? ShopId { get; set; }
        public decimal? VendorId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual InventoryLog InventoryLog { get; set; }
        public virtual ICollection<ProductReturn> ProductReturns { get; set; }
    }
}
