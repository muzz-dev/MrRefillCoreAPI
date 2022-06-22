using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class ProductMaster
    {
        public ProductMaster()
        {
            PurchaseDetails = new HashSet<PurchaseDetails>();
            PurchaseReturn = new HashSet<PurchaseReturn>();
            SalesDetails = new HashSet<SalesDetails>();
            SalesReturn = new HashSet<SalesReturn>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual ICollection<PurchaseReturn> PurchaseReturn { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
        public virtual ICollection<SalesReturn> SalesReturn { get; set; }
    }
}
