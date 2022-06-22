﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class SalesReturnExtend
    {
        public int SalesReturnId { get; set; }
        public int? SalesId { get; set; }
        public int? ProductId { get; set; }
        public string UserName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ReturnDate { get; set; }
        public string SalesDate { get; set; }
        public string ProductName { get; set; }
        public string ReturnAmount { get; set; }
        public string Quantity { get; set; }
        public string Remark { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}