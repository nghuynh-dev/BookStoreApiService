using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}