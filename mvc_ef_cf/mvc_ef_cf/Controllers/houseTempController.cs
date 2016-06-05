using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ef_cf.Controllers
{
    public class houseTempController : Controller
    {
        houseTempRestHelper tempHlpr = new houseTempRestHelper();

        // GET: houseTemp
        public ActionResult Index()
        {
            return View(tempHlpr.getHouseTemps());
        }

        // GET: houseTemp/Details/5
        public ActionResult Details(int id)
        {
            return View(tempHlpr.getHouseTempById(id));
        }

        // GET: houseTemp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: houseTemp/Create
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

        // GET: houseTemp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tempHlpr.getHouseTempById(id));
        }

        // POST: houseTemp/Edit/5
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

        // GET: houseTemp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: houseTemp/Delete/5
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

        // GET: houseTemp
        public ActionResult ChartArrayBasic()
        {
            return View(tempHlpr.getHouseTemps());
        }
    }
}
