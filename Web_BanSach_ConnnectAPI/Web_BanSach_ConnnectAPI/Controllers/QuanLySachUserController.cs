using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_BanSach_ConnnectAPI.Models;

namespace Web_BanSach_ConnnectAPI.Controllers
{
    public class QuanLySachUserController : Controller
    {
        ProductsAPI products = new ProductsAPI();
        ProductTypesAPI productTypesAPI = new ProductTypesAPI();
        CartsAPI cartsAPI = new CartsAPI();
        // GET: QuanLySach
        public ActionResult Index()
        {
            ViewBag.ds = products.GetData();

            ViewBag.type = productTypesAPI.getDataProductType(ViewBag.ds);

            return View();
        }
    }
}