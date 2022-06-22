using Microsoft.Ajax.Utilities;
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
    public class ProductTypesAPI
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/ProductTypes/"));
        string http = "https://localhost:44303/";

        ProductsAPI pro = new ProductsAPI();

        public List<ProductTypes> GetData()
        {
            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;

            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<ProductTypes> products = JsonConvert.DeserializeObject<List<ProductTypes>>(jsonString);

            return products;
        }

        public void PostData(string name, bool status)
        {
            using (var client = new HttpClient())
            {
                ProductTypes products = new ProductTypes { Name = name, Status = status };
                client.BaseAddress = new Uri(http);
                var response = client.PostAsJsonAsync("api/ProductTypes", products).Result;
            }
        }

        public void UpdateData(int id, string name, bool status)
        {
            using (var client = new HttpClient())
            {
                ProductTypes products = new ProductTypes { Id = id, Name = name, Status = status };
                client.BaseAddress = new Uri(http);
                if (products.Id == id)
                {
                    var response = client.PutAsJsonAsync("api/ProductTypes/" + products.Id, products).Result;
                }
                else
                {
                    return;
                }
            }
        }

        public void DeleteData(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(http);
                var response = client.DeleteAsync("api/ProductTypes/" + id).Result;
            }
        }

        public List<ProductsName> getDataProductType(List<Products> products)
        {
            List<ProductTypes> list = GetData();
            List<ProductsName> Name = new List<ProductsName>();
            foreach (var item in products)
            {
                foreach(var item1 in list)
                {
                    if(item1.Id == item.ProductTypeId)
                    {
                        ProductTypes productType = list.Where(a => a.Id == item.ProductTypeId).FirstOrDefault();
                        ProductsName name = new ProductsName();
                        name.Id = item1.Id;
                        name.Name = item1.Name;
                        Name.Add(name);
                    }    
                }    
            }
            return Name.DistinctBy(a => a.Id).ToList();
        }
    }
}