using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcDDL0;

namespace mvcDDL0.Controllers
{
    public class titlesController : Controller
    {
        private pubsModel db = new pubsModel();

        // GET: titles
        public ActionResult Index()
        {
            return View(db.titles.ToList());
        }

        // GET: titles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            title title = db.titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // GET: titles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "title_id,title1,type,pub_id,price,advance,royalty,ytd_sales,notes,pubdate")] title title)
        {
            if (ModelState.IsValid)
            {
                db.titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }

        // GET: titles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            title title = db.titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // POST: titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "title_id,title1,type,pub_id,price,advance,royalty,ytd_sales,notes,pubdate")] title title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(title);
        }

        // GET: titles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            title title = db.titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // POST: titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            title title = db.titles.Find(id);
            db.titles.Remove(title);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //jmh

        // GET: titles
        public ActionResult ddl0()
        {
            var distinctTypes = db.titles.Select(t => t.type).Distinct();
            ViewBag.bookTypes = new SelectList(distinctTypes);
            return View(db.titles.ToList());
        }

        public ActionResult ddl1(string title_id = "000000")
        {
            var distinctIds = db.titles.Select(t => t.title_id).Distinct();
            ViewBag.bookIds = new SelectList(distinctIds);
            return View(db.titles.Find(title_id));
        }

        [HttpPost]
        public ActionResult test0(string bookIds)
        {
            return View(db.titles.Find(bookIds));
        }
    }
}
