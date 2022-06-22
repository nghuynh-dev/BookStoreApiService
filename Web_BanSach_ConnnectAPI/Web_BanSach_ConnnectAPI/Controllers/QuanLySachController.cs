using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_BanSach_ConnnectAPI.Models;

namespace Web_BanSach_ConnnectAPI.Controllers
{
    public class QuanLySachController : Controller
    {
        ProductsAPI products = new ProductsAPI();
        ProductTypesAPI productTypesAPI = new ProductTypesAPI();
        // GET: QuanLySach
        public ActionResult Index()
        {
            ViewBag.ds = products.GetData();

            ViewBag.type = productTypesAPI.getDataProductType(ViewBag.ds);

            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = products.GetData().Where(a => a.Id == id).FirstOrDefault();
            ProductTypes product1 = productTypesAPI.GetData().Where(a => a.Id == product.ProductTypeId).FirstOrDefault();

            ViewBag.id = product1.Name;

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(productTypesAPI.GetData(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Productname,Description,Price,Image,ProductTypeId,SKU,Status,Stock")] Products product)
        {
            if (ModelState.IsValid)
            {
                products.PostData(product.Productname, product.Description, product.Price, product.Image, product.ProductTypeId, product.SKU, product.Status, product.Stock);
                return RedirectToAction("Index");
            }

            ViewBag.ProductTypeId = new SelectList(productTypesAPI.GetData(), "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = products.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(productTypesAPI.GetData(), "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Productname,Description,Price,Image,ProductTypeId,SKU,Status,Stock")] Products product)
        {
            if (ModelState.IsValid)
            {
                products.UpdateData(product.Id, product.Productname, product.Description, product.Price, product.Image, product.ProductTypeId, product.SKU, product.Status, product.Stock);
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(productTypesAPI.GetData(), "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = products.GetData().Where(a => a.Id == id).FirstOrDefault();

            ProductTypes product1 = productTypesAPI.GetData().Where(a => a.Id == product.ProductTypeId).FirstOrDefault();

            ViewBag.id = product1.Name;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products product = products.GetData().Where(a => a.Id == id).FirstOrDefault();
            products.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}