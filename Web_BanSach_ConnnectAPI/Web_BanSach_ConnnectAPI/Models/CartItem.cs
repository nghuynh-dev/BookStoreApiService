using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class CartItem
    {
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public double ThanhTien { get; set; }
    }
}