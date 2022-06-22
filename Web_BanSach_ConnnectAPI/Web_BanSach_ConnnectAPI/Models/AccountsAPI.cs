using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Formatting;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class AccountsAPI
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44303/api/Accounts/"));
        string http = "https://localhost:44303/";

        public List<Accounts> GetData()
        {
            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;

            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
                reader.Dispose();
            }

            List<Accounts> accounts = JsonConvert.DeserializeObject<List<Accounts>>(jsonString);

            return accounts;
        }


        public void PostData(string username, string pass, string email, string phone, string address, string fullname, bool isAdmin, string avatar, bool status)
        {
            using(var client = new HttpClient())
            {
                Accounts accounts = new Accounts { Username = username, Password = pass, Email = email, Phone = phone, Address = address, Fullname = fullname, IsAdmin = isAdmin, Avatar = avatar, Status = status };
                client.BaseAddress = new Uri(http);
                var response = client.PostAsJsonAsync("api/Accounts", accounts).Result;
            }
        }

        public void UpdateData(int id, string username, string pass, string email, string phone, string address, string fullname, bool isAdmin, string avatar, bool status)
        {
            using (var client = new HttpClient())
            {
                Accounts accounts = new Accounts {Id = id, Username = username, Password = pass, Email = email, Phone = phone, Address = address, Fullname = fullname, IsAdmin = isAdmin, Avatar = avatar, Status = status };
                client.BaseAddress = new Uri(http);
                if(accounts.Id == id)
                {
                    var response = client.PutAsJsonAsync("api/Accounts/" + accounts.Id, accounts).Result;
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
                var response = client.DeleteAsync("api/Accounts/" + id).Result;
            }
        }
    }
}