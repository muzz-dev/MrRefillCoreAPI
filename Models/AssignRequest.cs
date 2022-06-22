using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class AssignRequest
    {
        public int AssignId { get; set; }
        public int? UserId { get; set; }
        public int? ExchangeId { get; set; }
        public string Status { get; set; }
        public string PaymentMode { get; set; }
        public string IsPay { get; set; }
        public string Datetime { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ExchangeCartridge Exchange { get; set; }
        public virtual User User { get; set; }
    }
}
