using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class ExchangeCartridge
    {
        public ExchangeCartridge()
        {
            AssignRequest = new HashSet<AssignRequest>();
        }

        public int ExchangeId { get; set; }
        public int? UserId { get; set; }
        public int? CartridgeId { get; set; }
        public string Address { get; set; }
        public int? AreaId { get; set; }
        public int? ProblemId { get; set; }
        public string RequestDate { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual Area Area { get; set; }
        public virtual Cartridge Cartridge { get; set; }
        public virtual Problem Problem { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AssignRequest> AssignRequest { get; set; }
    }
}
