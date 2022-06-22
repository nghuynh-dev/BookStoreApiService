using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIBanSach.Models;

namespace APIBanSach.Controllers
{
    public class InvoiceDetailsController : ApiController
    {
        private BanHang2Entities9 db = new BanHang2Entities9();

        // GET: api/InvoiceDetails
        public IQueryable<InvoiceDetails> GetInvoiceDetails()
        {
            return db.InvoiceDetails;
        }

        // GET: api/InvoiceDetails/5
        [ResponseType(typeof(InvoiceDetails))]
        public IHttpActionResult GetInvoiceDetails(int id)
        {
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }

            return Ok(invoiceDetails);
        }

        // PUT: api/InvoiceDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvoiceDetails(int id, InvoiceDetails invoiceDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoiceDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(invoiceDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InvoiceDetails
        [ResponseType(typeof(InvoiceDetails))]
        public IHttpActionResult PostInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvoiceDetails.Add(invoiceDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = invoiceDetails.Id }, invoiceDetails);
        }

        // DELETE: api/InvoiceDetails/5
        [ResponseType(typeof(InvoiceDetails))]
        public IHttpActionResult DeleteInvoiceDetails(int id)
        {
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }

            db.InvoiceDetails.Remove(invoiceDetails);
            db.SaveChanges();

            return Ok(invoiceDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoiceDetailsExists(int id)
        {
            return db.InvoiceDetails.Count(e => e.Id == id) > 0;
        }
    }
}