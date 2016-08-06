using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrierIntegrator;
using CarrierIntegrator.Services;

namespace CarrierIntegrator.Controllers
{
    public class CarrerasController : Controller
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: Carreras
        public ActionResult Index()
        {
            var carreras = db.Carreras.Include(c => c.areas_car);

            return View(carreras);
        }

        public ActionResult TestProc()
        {
            var carreras = db.spMostrarCarreras(4);
            return View(carreras.ToList());
        }

        // GET: Carreras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_carrera,fk_area,nombre_carrera,descripcion_carrera")] Carreras carreras)
        {
            if (ModelState.IsValid)
            {
                db.Carreras.Add(carreras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area", carreras.fk_area);
            return View(carreras);
        }

        // GET: Carreras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area", carreras.fk_area);
            return View(carreras);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_carrera,fk_area,nombre_carrera,descripcion_carrera")] Carreras carreras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area", carreras.fk_area);
            return View(carreras);
        }

        // GET: Carreras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carreras carreras = db.Carreras.Find(id);
            db.Carreras.Remove(carreras);
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
    }
}
