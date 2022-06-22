using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanSach_ConnnectAPI.Models;

namespace Web_BanSach_ConnnectAPI.Controllers
{
    public class QuanLyHoaDonController : Controller
    {
        // GET: QuanLyHoaDon
        InvoicesAPI invoicesAPI = new InvoicesAPI();
        public ActionResult Index()
        {
            return View(invoicesAPI.GetData());
        }
    }
}