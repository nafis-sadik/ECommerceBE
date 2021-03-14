using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Product
    {
        public Product()
        {
            ShopProducts = new HashSet<ShopProduct>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductAttribute { get; set; }

        public virtual ICollection<ShopProduct> ShopProducts { get; set; }
    }
}
