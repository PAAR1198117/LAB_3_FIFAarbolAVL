using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class PartidosController : Controller
    {
        // GET: Partidos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Partidos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partidos/Create
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

        // GET: Partidos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partidos/Edit/5
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

        // GET: Partidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partidos/Delete/5
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
