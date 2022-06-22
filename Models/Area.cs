using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Area
    {
        public Area()
        {
            ExchangeCartridge = new HashSet<ExchangeCartridge>();
            User = new HashSet<User>();
        }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ICollection<ExchangeCartridge> ExchangeCartridge { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
