﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Inventorylog
    {
        public decimal InventoryLogId { get; set; }
        public decimal Pk { get; set; }
        public decimal TransactionQuantity { get; set; }
        public string TransactionDate { get; set; }
        public decimal QuantityUpdateType { get; set; }

        public virtual Shopproduct InventoryLog { get; set; }
        public virtual Commoncode QuantityUpdateTypeNavigation { get; set; }
    }
}
