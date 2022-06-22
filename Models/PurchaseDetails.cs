using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class PurchaseDetails
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public string BuyPrice { get; set; }
        public string Quantity { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ProductMaster Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
