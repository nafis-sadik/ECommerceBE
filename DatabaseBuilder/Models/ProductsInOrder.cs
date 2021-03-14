using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class ProductsInOrder
    {
        public decimal Pk { get; set; }
        public decimal OrderId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual ShopProduct PkNavigation { get; set; }
    }
}
