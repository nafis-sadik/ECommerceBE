using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Product
    {
        public Product()
        {
            Shopproducts = new HashSet<Shopproduct>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductAttribute { get; set; }

        public virtual ICollection<Shopproduct> Shopproducts { get; set; }
    }
}
