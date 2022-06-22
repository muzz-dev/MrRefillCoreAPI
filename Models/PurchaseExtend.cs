using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class PurchaseExtend
    {
        public int PurchaseId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string PurchaseDate { get; set; }
        public string TotalPayment { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
