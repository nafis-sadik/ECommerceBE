using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
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
