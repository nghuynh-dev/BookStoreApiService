using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_BanSach_ConnnectAPI.Models;

namespace BLL
{
    public class Products_BLL
    {
        ProductsAPI products = new ProductsAPI();
        public List<Products> GetData()
        {
            return products.GetData();
        }

        public void PostData(string productname, string des, float price, string image, int productTypeId, string sku, bool status, int stock)
        {
            products.PostData(productname, des, price, image, productTypeId, sku, status, stock);
        }

        public void UpdateData(int id, string productname, string des, float price, string image, int productTypeId, string sku, bool status, int stock)
        {
            products.UpdateData(id, productname, des, price, image, productTypeId, sku, status, stock);
        }

        public void DeleteData(int id)
        {
            products.DeleteData(id);
        }
    }
}
