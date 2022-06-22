using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Transaction
    {
        public int TranscationId { get; set; }
        public int? PurchaseId { get; set; }
        public int? PurchaseReturnId { get; set; }
        public int? SalesId { get; set; }
        public int? SalesReturnId { get; set; }
        public string Type { get; set; }
        public string TransactionDate { get; set; }
        public string Amount { get; set; }
        public string Remark { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
