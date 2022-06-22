using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class ModelCompanyType
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
