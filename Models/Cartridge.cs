using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Cartridge
    {
        public Cartridge()
        {
            ExchangeCartridge = new HashSet<ExchangeCartridge>();
        }

        public int CartridgeId { get; set; }
        public string CartridgeName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int? ModelId { get; set; }
        public int? TypeId { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual Model Model { get; set; }
        public virtual CartridgeType Type { get; set; }
        public virtual ICollection<ExchangeCartridge> ExchangeCartridge { get; set; }
    }
}
