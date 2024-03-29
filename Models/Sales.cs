﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class Sales
    {
        public Sales()
        {
            SalesDetails = new HashSet<SalesDetails>();
            SalesReturn = new HashSet<SalesReturn>();
        }

        public int SalesId { get; set; }
        public int? UserId { get; set; }
        public string SalesDate { get; set; }
        public string TotalPayment { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
        public virtual ICollection<SalesReturn> SalesReturn { get; set; }
    }
}
