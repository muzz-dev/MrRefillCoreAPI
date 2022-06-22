using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class PurchaseReturn
    {
        public int PurchaseReturnId { get; set; }
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public string ReturnAmount { get; set; }
        public string Quantity { get; set; }
        public string Remark { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ProductMaster Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
