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
    public class InvoiceDetailsAPI
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/InvoiceDetails/"));
        string http = "https://localhost:44303/";

        public List<InvoiceDetails> GetData()
        {
            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;

            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
                reader.Close();
            }

            List<InvoiceDetails> invoicesdl = JsonConvert.DeserializeObject<List<InvoiceDetails>>(jsonString);

            return invoicesdl;
        }

        public void PostData(int ivid, int proid, int quan, int unitprice, int accid)
        {
            using (var client = new HttpClient())
            {
                InvoiceDetails invoicesdl = new InvoiceDetails {InvoiceId = ivid, ProductId = proid, Quantity = quan, UnitPrice = unitprice, AccountID = accid};
                client.BaseAddress = new Uri(http);
                var response = client.PostAsJsonAsync("api/InvoiceDetails", invoicesdl).Result;
            }
        }

        public void UpdateData(int id, int ivid, int proid, int quan, int unitprice, int accid)
        {
            using (var client = new HttpClient())
            {
                InvoiceDetails invoicesdl = new InvoiceDetails { Id = id, InvoiceId = ivid, ProductId = proid, Quantity = quan, UnitPrice = unitprice, AccountID = accid };
                client.BaseAddress = new Uri(http);
                if (invoicesdl.Id == id)
                {
                    var response = client.PutAsJsonAsync("api/InvoiceDetails/" + invoicesdl.Id, invoicesdl).Result;
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
                var response = client.DeleteAsync("api/InvoiceDetails/" + id).Result;
            }
        }
    }
}