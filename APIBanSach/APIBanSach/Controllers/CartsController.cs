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
    public class CartsController : ApiController
    {
        private BanHang2Entities db = new BanHang2Entities();

        // GET: api/Carts
        public IQueryable<Carts> GetCarts()
        {
            return db.Carts;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(Carts))]
        public IHttpActionResult GetCarts(int id)
        {
            Carts carts = db.Carts.Find(id);
            if (carts == null)
            {
                return NotFound();
            }

            return Ok(carts);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarts(int id, Carts carts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carts.Id)
            {
                return BadRequest();
            }

            db.Entry(carts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartsExists(id))
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

        // POST: api/Carts
        [ResponseType(typeof(Carts))]
        public IHttpActionResult PostCarts(Carts carts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(carts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carts.Id }, carts);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Carts))]
        public IHttpActionResult DeleteCarts(int id)
        {
            Carts carts = db.Carts.Find(id);
            if (carts == null)
            {
                return NotFound();
            }

            db.Carts.Remove(carts);
            db.SaveChanges();

            return Ok(carts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartsExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}