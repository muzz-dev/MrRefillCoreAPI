using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Models
{
    public class FeedbackExtend
    {
        public int FeedbackId { get; set; }
        public string FeedbackText { get; set; }
        public string Username { get; set; }
        public string Date { get; set; }
    }
}
