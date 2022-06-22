using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class UserDetails
    {
        public string token { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public string GstNumber { get; set; }
        public string Otp { get; set; }
        public string Type { get; set; }
        public string RegisterBy { get; set; }
        public string IsVerify { get; set; }
        public string IsBlock { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
