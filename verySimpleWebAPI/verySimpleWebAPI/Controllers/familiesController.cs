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
using verySimpleWebAPI;

namespace verySimpleWebAPI.Controllers
{
    public class familiesController : ApiController
    {
        private famModel db = new famModel();

        // GET: api/families
        public IQueryable<family> Getfamilies()
        {
            return db.families;
        }

        // GET: api/families/5
        [ResponseType(typeof(family))]
        public IHttpActionResult Getfamily(int id)
        {
            family family = db.families.Find(id);
            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        // PUT: api/families/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfamily(int id, family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != family.Id)
            {
                return BadRequest();
            }

            db.Entry(family).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!familyExists(id))
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

        // POST: api/families
        [ResponseType(typeof(family))]
        public IHttpActionResult Postfamily(family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.families.Add(family);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (familyExists(family.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = family.Id }, family);
        }

        // DELETE: api/families/5
        [ResponseType(typeof(family))]
        public IHttpActionResult Deletefamily(int id)
        {
            family family = db.families.Find(id);
            if (family == null)
            {
                return NotFound();
            }

            db.families.Remove(family);
            db.SaveChanges();

            return Ok(family);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool familyExists(int id)
        {
            return db.families.Count(e => e.Id == id) > 0;
        }
    }
}