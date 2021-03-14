using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            ShopProducts = new HashSet<ShopProduct>();
        }

        public decimal SubCategoryId { get; set; }
        public decimal? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryNameBangla { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ShopProduct> ShopProducts { get; set; }
    }
}
