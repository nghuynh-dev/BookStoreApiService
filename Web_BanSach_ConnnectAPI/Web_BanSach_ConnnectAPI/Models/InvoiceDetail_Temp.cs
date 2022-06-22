using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class InvoiceDetail_Temp
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int AccountID { get; set; }
    }
}