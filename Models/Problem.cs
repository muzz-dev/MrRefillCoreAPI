using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Problem
    {
        public Problem()
        {
            ExchangeCartridge = new HashSet<ExchangeCartridge>();
        }

        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public string Price { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ICollection<ExchangeCartridge> ExchangeCartridge { get; set; }
    }
}
