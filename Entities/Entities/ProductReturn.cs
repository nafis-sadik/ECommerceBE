using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class ProductReturn
    {
        public decimal ProductReturnId { get; set; }
        public decimal OrderId { get; set; }
        public DateTime? ReturnRequestDate { get; set; }
        public decimal Pk { get; set; }
        public decimal? ReturnQuantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual ShopProduct PkNavigation { get; set; }
    }
}
