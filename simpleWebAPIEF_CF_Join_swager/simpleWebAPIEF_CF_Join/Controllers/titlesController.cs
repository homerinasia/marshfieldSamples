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
    public class titlesController : ApiController
    {
        private pubsModel db = new pubsModel();

        // GET: api/titles
        public IQueryable<title> Gettitles()
        {
            return db.titles;
        }

        // GET: api/titles
        [Route ("api/jt")]
        public List<smallTitle> GetsmallTitles()
        {   
            return db.smallTitles.ToList();
        }

        // GET: api/titles/5
        [ResponseType(typeof(title))]
        public IHttpActionResult Gettitle(string id)
        {
            title title = db.titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT: api/titles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttitle(string id, title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.title_id)
            {
                return BadRequest();
            }

            db.Entry(title).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!titleExists(id))
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

        // POST: api/titles
        [ResponseType(typeof(title))]
        public IHttpActionResult Posttitle(title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.titles.Add(title);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (titleExists(title.title_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = title.title_id }, title);
        }

        // DELETE: api/titles/5
        [ResponseType(typeof(title))]
        public IHttpActionResult Deletetitle(string id)
        {
            title title = db.titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            db.titles.Remove(title);
            db.SaveChanges();

            return Ok(title);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool titleExists(string id)
        {
            return db.titles.Count(e => e.title_id == id) > 0;
        }
    }
}