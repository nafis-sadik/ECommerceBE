using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class Order
    {
        public Order()
        {
            Productreturns = new HashSet<Productreturn>();
        }

        public decimal OrderId { get; set; }
        public string DeliveryLocation { get; set; }
        public decimal UserId { get; set; }
        public string OrderDescription { get; set; }
        public decimal? PaymentOption { get; set; }
        public decimal? TotalOrderValue { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Productreturn> Productreturns { get; set; }
    }
}
