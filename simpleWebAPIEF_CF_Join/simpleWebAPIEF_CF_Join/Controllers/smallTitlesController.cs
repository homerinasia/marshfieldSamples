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

namespace simpleWebAPIEF_CF_Join
{
    public class smallTitlesController : ApiController
    {
        private pubsModel db = new pubsModel();

        // GET: api/smallTitles
        public IQueryable<smallTitle> GetsmallTitles()
        {
            return db.smallTitles;
        }

        // GET: api/smallTitles/5
        [ResponseType(typeof(smallTitle))]
        public IHttpActionResult GetsmallTitle(string id)
        {
            smallTitle smallTitle = db.smallTitles.Find(id);
            if (smallTitle == null)
            {
                return NotFound();
            }

            return Ok(smallTitle);
        }

        // PUT: api/smallTitles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsmallTitle(string id, smallTitle smallTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smallTitle.title_id)
            {
                return BadRequest();
            }

            db.Entry(smallTitle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!smallTitleExists(id))
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

        // POST: api/smallTitles
        [ResponseType(typeof(smallTitle))]
        public IHttpActionResult PostsmallTitle(smallTitle smallTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.smallTitles.Add(smallTitle);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (smallTitleExists(smallTitle.title_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = smallTitle.title_id }, smallTitle);
        }

        // DELETE: api/smallTitles/5
        [ResponseType(typeof(smallTitle))]
        public IHttpActionResult DeletesmallTitle(string id)
        {
            smallTitle smallTitle = db.smallTitles.Find(id);
            if (smallTitle == null)
            {
                return NotFound();
            }

            db.smallTitles.Remove(smallTitle);
            db.SaveChanges();

            return Ok(smallTitle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool smallTitleExists(string id)
        {
            return db.smallTitles.Count(e => e.title_id == id) > 0;
        }
    }
}