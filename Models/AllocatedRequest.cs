using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class AllocatedRequest
    {
        public int ExchangeId { get; set; }
        public int AssignId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string userContactNumber { get; set; }
        public string employeeContactNumber { get; set; }
        public int? CartridgeId { get; set; }
        public string CartridgeName { get; set; }
        public string Address { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public string Remark { get; set; }
        public int? ProblemId { get; set; }
        public string Amount { get; set; }
        public string PaymentMode { get; set; }
        public string Datetime { get; set; }
        public string RequestDate { get; set; }
        public string Status { get; set; }
        public string IsComplete { get; set; }
        public string IsPay { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
