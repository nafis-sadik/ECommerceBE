using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Page_ProductListPage
    {
        public IList<Product_ProductListPage> Products { get; set; }
        public string SearchString { get; set; }
        public int SortByCategory { get; set; }
        public int PageNo { get; set; }
        public int ShopId { get; set; }
        public int PriceRange_LowerBound { get; set; }
        public int PriceRange_UpperBound { get; set; }
    }
}
