using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class User
    {
        public User()
        {
            AssignRequest = new HashSet<AssignRequest>();
            ExchangeCartridge = new HashSet<ExchangeCartridge>();
            Feedback = new HashSet<Feedback>();
            Purchase = new HashSet<Purchase>();
            Sales = new HashSet<Sales>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int? AreaId { get; set; }
        public string GstNumber { get; set; }
        public string Otp { get; set; }
        public string Type { get; set; }
        public string RegisterBy { get; set; }
        public string IsVerify { get; set; }
        public string IsBlock { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<AssignRequest> AssignRequest { get; set; }
        public virtual ICollection<ExchangeCartridge> ExchangeCartridge { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
