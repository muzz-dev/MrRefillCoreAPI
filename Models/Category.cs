using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductMaster = new HashSet<ProductMaster>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ICollection<ProductMaster> ProductMaster { get; set; }
    }
}
