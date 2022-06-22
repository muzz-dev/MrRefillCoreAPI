using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class CartridgeModelType
    {
        public int CartridgeId { get; set; }
        public string CartridgeName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int? ModelId { get; set; }
        public string ModelName { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
