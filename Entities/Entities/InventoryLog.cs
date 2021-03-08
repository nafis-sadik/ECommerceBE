using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class InventoryLog
    {
        public decimal Pk { get; set; }
        public decimal InventoryLogId { get; set; }
        public decimal TransactionQuantity { get; set; }
        public string TransactionDate { get; set; }
        public decimal QuantityUpdateType { get; set; }

        public virtual ShopProduct InventoryLogNavigation { get; set; }
        public virtual CommonCode QuantityUpdateTypeNavigation { get; set; }
    }
}
