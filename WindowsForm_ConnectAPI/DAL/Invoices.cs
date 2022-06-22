using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class Invoices
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int AccountId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public double Total { get; set; }
        public bool Status { get; set; }
    }
}