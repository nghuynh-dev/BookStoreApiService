using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_BanSach_ConnnectAPI.Models;

namespace Web_BanSach_ConnnectAPI.Controllers
{
    public class QuanLyLoaiSachController : Controller
    {
        ProductTypesAPI productTypesAPI = new ProductTypesAPI();
        // GET: QuanLyLoaiSach
        public ActionResult Index()
        {
            return View(productTypesAPI.GetData());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status")] ProductTypes product)
        {
            if (ModelState.IsValid)
            {
                productTypesAPI.PostData(product.Name, product.Status);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypes product = productTypesAPI.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status")] ProductTypes product)
        {
            if (ModelState.IsValid)
            {
                productTypesAPI.UpdateData(product.Id, product.Name, product.Status);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypes product = productTypesAPI.GetData().Where(a => a.Id == id).FirstOrDefault();

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
            ProductTypes product = productTypesAPI.GetData().Where(a => a.Id == id).FirstOrDefault();
            productTypesAPI.DeleteData(id);
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypes product = productTypesAPI.GetData().Where(a => a.Id == id).FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}