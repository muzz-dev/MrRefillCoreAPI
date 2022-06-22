using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class SalesDetails
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public string SalesPrice { get; set; }
        public string Quantity { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ProductMaster Product { get; set; }
        public virtual Sales Sales { get; set; }
    }
}
