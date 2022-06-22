using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class ProductsAPI
    {

        public List<Products> GetData()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Products/"));
            string http = "https://localhost:44303/";
            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;

            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(jsonString);

            return products;
        }

        public void PostData(string productname, string des, float price, string image, int productTypeId, string sku, bool status, int stock)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Products/"));
            string http = "https://localhost:44303/";
            using (var client = new HttpClient())
            {
                Products products = new Products { Productname = productname, Description = des, Price = price, Image = image, ProductTypeId = productTypeId, SKU = sku, Status = status, Stock = stock};
                client.BaseAddress = new Uri(http);
                var response = client.PostAsJsonAsync("api/Products", products).Result;
            }
        }

        public void UpdateData(int id, string productname, string des, float price, string image, int productTypeId, string sku, bool status, int stock)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Products/"));
            string http = "https://localhost:44303/";
            using (var client = new HttpClient())
            {
                Products products = new Products {Id = id, Productname = productname, Description = des, Price = price, Image = image, ProductTypeId = productTypeId, SKU = sku, Status = status, Stock = stock };
                client.BaseAddress = new Uri(http);
                if (products.Id == id)
                {
                    var response = client.PutAsJsonAsync("api/Products/" + products.Id, products).Result;
                }
                else
                {
                    return;
                }
            }
        }

        public void DeleteData(int id)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Products/"));
            string http = "https://localhost:44303/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(http);
                var response = client.DeleteAsync("api/Products/" + id).Result;
            }
        }
    }
}