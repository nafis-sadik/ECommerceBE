using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class ProductImg
    {
        public string ProductImgLocation { get; set; }
        public decimal? Pk { get; set; }

        public virtual ShopProduct PkNavigation { get; set; }
    }
}
