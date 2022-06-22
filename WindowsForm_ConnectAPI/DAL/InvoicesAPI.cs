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
    public class InvoicesAPI
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Invoices/"));
        string http = "https://localhost:44303/";

        public List<Invoices> GetData()
        {
            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;

            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Invoices> invoices = JsonConvert.DeserializeObject<List<Invoices>>(jsonString);

            return invoices;
        }

        public void PostData(string code, int account, DateTime date, string address, string phonne, double total, bool status)
        {
            using (var client = new HttpClient())
            {
                Invoices invoices = new Invoices {Code = code, AccountId = account, IssuedDate = date, ShippingAddress = address, ShippingPhone = phonne, Total = total, Status = status};
                client.BaseAddress = new Uri(http);
                var response = client.PostAsJsonAsync("api/Invoices", invoices).Result;
            }
        }

        public void UpdateData(int id, string code, int account, DateTime date, string address, string phonne, double total, bool status)
        {
            using (var client = new HttpClient())
            {
                Invoices invoices = new Invoices {Id = id, Code = code, AccountId = account, IssuedDate = date, ShippingAddress = address, ShippingPhone = phonne, Total = total, Status = status };
                client.BaseAddress = new Uri(http);
                if (invoices.Id == id)
                {
                    var response = client.PutAsJsonAsync("api/Invoices/" + invoices.Id, invoices).Result;
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
                var response = client.DeleteAsync("api/Invoices/" + id).Result;
            }
        }
    }
}