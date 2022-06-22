using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanSach_ConnnectAPI.Models
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public bool IsAdmin { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }
    }
}