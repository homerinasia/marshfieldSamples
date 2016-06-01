using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSwaggerClient;


namespace mvcSwaggerClient.Controllers
{
    public class jmhController : Controller
    {
        private SimpleWebAPIEFCFJoin myData = new SimpleWebAPIEFCFJoin();

        // GET: jmh
        public ActionResult Index()
        {
            return View(myData.Sales.Getsales());
        }

        // GET: jmh/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: jmh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jmh/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: jmh/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: jmh/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: jmh/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: jmh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
