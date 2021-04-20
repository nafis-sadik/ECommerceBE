using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Shopproducts = new HashSet<Shopproduct>();
        }

        public decimal SubCategoryId { get; set; }
        public decimal? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryNameBangla { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Shopproduct> Shopproducts { get; set; }
    }
}
