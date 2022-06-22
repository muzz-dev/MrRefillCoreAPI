using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Model
    {
        public Model()
        {
            Cartridge = new HashSet<Cartridge>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int? CompanyId { get; set; }
        public string Type { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ICollection<Cartridge> Cartridge { get; set; }
    }
}
