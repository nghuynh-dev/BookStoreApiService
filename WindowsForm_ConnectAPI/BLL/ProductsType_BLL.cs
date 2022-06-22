using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_BanSach_ConnnectAPI.Models;

namespace BLL
{
    public class ProductsType_BLL
    {
        ProductTypesAPI products = new ProductTypesAPI();
        public List<ProductTypes> GetData()
        {
            return products.GetData();
        }
    }
}
