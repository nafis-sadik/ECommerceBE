using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ProductGridProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public bool HasDiscount { get; set; }
        public float DiscountPercentage { get; set; }
        public string ProductImgUrl { get; set; }
    }
}
