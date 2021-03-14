using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal? CategoryNameBangla { get; set; }
        public decimal? ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
