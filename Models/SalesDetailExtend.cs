using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class SalesDetailExtend
    {
        public int SalesId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string SalesDate { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
