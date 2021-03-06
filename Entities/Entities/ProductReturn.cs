﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Productreturn
    {
        public decimal ProductReturnId { get; set; }
        public decimal OrderId { get; set; }
        public decimal Pk { get; set; }
        public decimal? ReturnQuantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Shopproduct PkNavigation { get; set; }
    }
}
