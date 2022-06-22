using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_BanSach_ConnnectAPI.Models;

namespace BLL
{
    public class Accounts_BLL
    {
        private AccountsAPI accounts = new AccountsAPI();

        public List<Accounts> DanhSach()
        {
            var ds = accounts.GetData();

            return ds;
        }

        public int Login(string name, string matkhau)
        {
            try
            {
                var obj = accounts.GetData().Where(a => a.Username.Equals(name) && a.Password.Equals(matkhau)).FirstOrDefault();
                if (obj != null)
                {
                    return obj.Id;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool PostData(string username, string pass, string email, string phone, string address, string fullname, bool isAdmin, string avatar, bool status)
        {
            try
            {
                accounts.PostData(username, pass, email, phone, address, fullname, isAdmin, avatar, status);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateData(int id, string username, string pass, string email, string phone, string address, string fullname, bool isAdmin, string avatar, bool status)
        {
            try
            {
                accounts.UpdateData(id, username, pass, email, phone, address, fullname, isAdmin, avatar, status);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteData(int id)
        {
            try
            {
                accounts.DeleteData(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
