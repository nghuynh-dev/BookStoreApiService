using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int ProductTypeId { get; set; }
        public string SKU { get; set; }
        public bool Status { get; set; }
        public int Stock { get; set; }
    }
}