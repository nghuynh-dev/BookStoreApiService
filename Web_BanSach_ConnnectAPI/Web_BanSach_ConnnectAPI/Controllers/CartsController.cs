using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanSach_ConnnectAPI.Models;

namespace Web_BanSach_ConnnectAPI.Controllers
{
    public class CartsController : Controller
    {
        ProductsAPI productsAPI = new ProductsAPI();
        InvoicesAPI invoicesAPI = new InvoicesAPI();
        InvoiceDetailsAPI invoicesDetailsAPI = new InvoiceDetailsAPI();
        List<GetAccountID_InvoicesID> temp;
        List<InvoiceDetail_Temp> invoiceDetail_Temps;
        // GET: Carts
        public ActionResult Index()
        {
            var tam = Session["giohang"];
            List<CartItem> lst = new List<CartItem>();
            if(tam != null)
            {
                lst = (List<CartItem>)tam;

                double sum = lst.Sum(a => a.ThanhTien);
                ViewBag.Tong = sum;
                Session["sum"] = sum;
            }    
            return View(lst);
        }

        [HttpPost]
        public ActionResult Add()
        {
            int id = int.Parse(Request.Form["Id"]);
            int quantity = int.Parse(Request.Form["Quantity"]);
            // Thêm vào session
            var tam = Session["giohang"];
            List<CartItem> lstCart = new List<CartItem>();
            if (tam == null)
            {
                Products p = productsAPI.GetData().Where(a => a.Id == id).FirstOrDefault();
                CartItem item = new CartItem();
                item.Products = p;
                item.Quantity = quantity;
                item.ThanhTien = item.Products.Price * item.Quantity;
                lstCart.Add(item);
                Session["giohang"] = lstCart;

                double sum = lstCart.Sum(a => a.ThanhTien);
                ViewBag.Tong = sum;
            }
            else
            {
                lstCart = (List<CartItem>)tam;
                if (lstCart.Exists(x => x.Products.Id == id))
                {
                    foreach (CartItem i in lstCart)
                        if (i.Products.Id == id)
                        {
                            i.Quantity += quantity;
                            i.ThanhTien = i.Products.Price * i.Quantity;
                        }

                    double sum = lstCart.Sum(a => a.ThanhTien);
                    ViewBag.Tong = sum;
                }
                else
                {
                    Products p = productsAPI.GetData().Where(a => a.Id == id).FirstOrDefault();
                    CartItem item = new CartItem();
                    item.Products = p;
                    item.Quantity = quantity;
                    item.ThanhTien = item.Products.Price * item.Quantity;
                    lstCart.Add(item);

                    double sum = lstCart.Sum(a => a.ThanhTien);
                    ViewBag.Tong = sum;
                }
            }

            Session["giohang"] = lstCart;
            // Quay về index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update()
        {
            int id = int.Parse(Request.Form["Id"]);
            int quantity = int.Parse(Request.Form["Quantity"]);
            var tam = Session["giohang"];
            if (tam != null)
            {
                List<CartItem> list = new List<CartItem>();
                list = (List<CartItem>)tam;
                foreach (CartItem i in list)
                {
                    if (i.Products.Id == id)
                    {
                        i.Quantity = quantity;
                        i.ThanhTien = i.Products.Price * i.Quantity;
                    }
                }

                double sum = list.Sum(a => a.ThanhTien);
                ViewBag.Tong = sum;
                Session["giohang"] = list; 
            }
            if (Request.Form["xoa"] != null)
            {
                List<CartItem> list = new List<CartItem>();
                list = (List<CartItem>)tam;
                foreach (CartItem i in list)
                {
                    if (i.Products.Id == id)
                    {
                        var x = list.Where(a => a.Products.Id == id).FirstOrDefault();
                        list.Remove(x);
                        break;
                    }
                }

                double sum = list.Sum(a => a.ThanhTien);
                ViewBag.Tong = sum;
                Session["giohang"] = list;
            }
            return RedirectToAction("Index");
        }

        //Get
        public ActionResult ThanhToan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThanhToanHoaDon()
        {
            string code = Request.Form["code"];
            DateTime issuedDate = DateTime.Now;
            string address = Request.Form["address"];
            string phone = Request.Form["phone"];

            invoiceDetail_Temps = invoicesDetailsAPI.GetData().Select(a => new InvoiceDetail_Temp { Id = a.Id, InvoiceId = a.InvoiceId, ProductId = a.ProductId, Quantity = a.Quantity, UnitPrice = a.UnitPrice, AccountID = a.AccountID }).ToList();

            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "QuanLyAccounts");
            }

            else
            {
                int idkh = int.Parse(Session["Id"].ToString());

                double sum = double.Parse(Session["sum"].ToString());

                invoicesAPI.PostData(code, idkh, issuedDate, address, phone, sum, true);

                temp = invoicesAPI.GetData().Select(a => new GetAccountID_InvoicesID { AccountID = int.Parse(Session["Id"].ToString()), InvoicesID = a.Id }).ToList();

                foreach(var item2 in temp)
                {
                    if(invoiceDetail_Temps.Any(x => x.AccountID == item2.AccountID && x.InvoiceId == item2.InvoicesID) == false)
                    {
                        foreach (var item in (List<CartItem>)Session["giohang"])
                        {
                            invoicesDetailsAPI.PostData(item2.InvoicesID, item.Products.Id, item.Quantity, int.Parse(item.Products.Price.ToString()), item2.AccountID);

                            productsAPI.UpdateData(item.Products.Id, item.Products.Productname, item.Products.Description, item.Products.Price, item.Products.Image, item.Products.ProductTypeId, item.Products.SKU, item.Products.Status, item.Products.Stock - item.Quantity);
                        }
                    } 
                }    
                return RedirectToAction("Index", "QuanLySachUser");
            }
        }
    }
}