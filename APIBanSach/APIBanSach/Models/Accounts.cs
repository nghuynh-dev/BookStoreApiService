//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIBanSach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accounts
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
