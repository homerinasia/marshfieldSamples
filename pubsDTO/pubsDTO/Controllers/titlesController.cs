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
using pubsDTO;
using pubsDTO.Models;

namespace pubsDTO.Controllers
{
    public class titlesController : ApiController
    {
        private pubsModel db = new pubsModel();

        // GET: api/titles
        public IQueryable<titlesDTO> Gettitles()
        {
            //return db.titles;
            var titles = from t in db.titles
                         select new titlesDTO()
                         {
                             title_id = t.title_id,
                             title = t.title1,
                             type = t.type,
                             pubName = t.publisher.pub_name, // navigation!!
                             ytd_sales=t.ytd_sales,
                             pubdate=t.pubdate
                         };
            return titles;
        }

        // GET: api/titles/5
        [ResponseType(typeof(titlesDTO))]
        public IHttpActionResult Gettitle(string id)
        {
            //title title = db.titles.Find(id);
            var title = db.titles.Select(t =>
                new titlesDTO()
                {
                    title_id = t.title_id,
                    title = t.title1,
                    type = t.type,
                    pubName = t.publisher.pub_name, // navigation!!
                    ytd_sales = t.ytd_sales,
                    pubdate = t.pubdate
                }).SingleOrDefault(t => t.title_id == id);

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