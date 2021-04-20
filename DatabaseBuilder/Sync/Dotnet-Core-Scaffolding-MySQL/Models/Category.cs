using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameBangla { get; set; }
        public decimal? ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
