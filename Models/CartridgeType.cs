using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class CartridgeType
    {
        public CartridgeType()
        {
            Cartridge = new HashSet<Cartridge>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Cartridge> Cartridge { get; set; }
    }
}
