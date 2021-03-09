using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Order
    {
        public Order()
        {
            ProductReturns = new HashSet<ProductReturn>();
        }

        public decimal OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string DeliveryLocation { get; set; }
        public decimal UserId { get; set; }
        public string OrderDescription { get; set; }
        public decimal? PaymentOption { get; set; }
        public decimal? TotalOrderValue { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProductReturn> ProductReturns { get; set; }
    }
}
