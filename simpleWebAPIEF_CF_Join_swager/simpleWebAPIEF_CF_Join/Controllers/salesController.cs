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
using simpleWebAPIEF_CF_Join;

namespace simpleWebAPIEF_CF_Join.Controllers
{
    public class salesController : ApiController
    {
        private pubsModel db = new pubsModel();

        // GET: api/sales
        public IQueryable<sale> Getsales()
        {
            return db.sales;
        }

        // GET: api/sales/5
        [ResponseType(typeof(sale))]
        public IHttpActionResult Getsale(string id)
        {
            sale sale = db.sales.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsale(string id, sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.stor_id)
            {
                return BadRequest();
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!saleExists(id))
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

        // POST: api/sales
        [ResponseType(typeof(sale))]
        public IHttpActionResult Postsale(sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sales.Add(sale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (saleExists(sale.stor_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sale.stor_id }, sale);
        }

        // DELETE: api/sales/5
        [ResponseType(typeof(sale))]
        public IHttpActionResult Deletesale(string id)
        {
            sale sale = db.sales.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.sales.Remove(sale);
            db.SaveChanges();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool saleExists(string id)
        {
            return db.sales.Count(e => e.stor_id == id) > 0;
        }
    }
}