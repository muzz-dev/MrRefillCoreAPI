using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseDetails = new HashSet<PurchaseDetails>();
            PurchaseReturn = new HashSet<PurchaseReturn>();
        }

        public int PurchaseId { get; set; }
        public int? UserId { get; set; }
        public string PurchaseDate { get; set; }
        public string TotalPayment { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual ICollection<PurchaseReturn> PurchaseReturn { get; set; }
    }
}
