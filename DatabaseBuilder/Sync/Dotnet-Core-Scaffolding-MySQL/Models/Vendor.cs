using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Shopproducts = new HashSet<Shopproduct>();
        }

        public decimal VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string Remarks { get; set; }
        public decimal ShopId { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual ICollection<Shopproduct> Shopproducts { get; set; }
    }
}
