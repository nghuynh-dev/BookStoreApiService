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
    public class CartsAPI
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Carts/"));
        string http = "https://localhost:44303/";

        public List<Carts> GetData()
        {
            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;

            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Carts> carts = JsonConvert.DeserializeObject<List<Carts>>(jsonString);

            return carts;
        }

        public void PostData(int accountId, int productId, int quantity)
        {
            using (var client = new HttpClient())
            {
                Carts carts = new Carts {AccountId = accountId, ProductId = productId, Quantity = quantity };
                client.BaseAddress = new Uri(http);
                var response = client.PostAsJsonAsync("api/Carts", carts).Result;
            }
        }

        public void UpdateData(int id, int accountId, int productId, int quantity)
        {
            using (var client = new HttpClient())
            {
                Carts carts = new Carts { Id = id, AccountId = accountId, ProductId = productId, Quantity = quantity };
                client.BaseAddress = new Uri(http);
                if (carts.Id == id)
                {
                    var response = client.PutAsJsonAsync("api/Carts/" + carts.Id, carts).Result;
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
                var response = client.DeleteAsync("api/Carts/" + id).Result;
            }
        }
    }
}