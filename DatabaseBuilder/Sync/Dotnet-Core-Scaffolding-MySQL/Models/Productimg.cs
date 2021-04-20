using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Productimg
    {
        public string ProductImgLocation { get; set; }
        public decimal? Pk { get; set; }

        public virtual Shopproduct PkNavigation { get; set; }
    }
}
