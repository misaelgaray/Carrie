using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrierIntegrator;

namespace CarrierIntegrator.Controllers
{
    public class pregunta_areaController : Controller
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: pregunta_area
        public ActionResult Index()
        {
            var pregunta_area = db.pregunta_area.Include(p => p.areas_car).Include(p => p.Preguntas);
            return View(pregunta_area.ToList());
        }

        // GET: pregunta_area/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta_area pregunta_area = db.pregunta_area.Find(id);
            if (pregunta_area == null)
            {
                return HttpNotFound();
            }
            return View(pregunta_area);
        }

        // GET: pregunta_area/Create
        public ActionResult Create()
        {
            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area");
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "id_pregunta");
            return View();
        }

        // POST: pregunta_area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pregunta_area,fk_pregunta,fk_area")] pregunta_area pregunta_area)
        {
            if (ModelState.IsValid)
            {
                db.pregunta_area.Add(pregunta_area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area", pregunta_area.fk_area);
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta", pregunta_area.fk_pregunta);
            return View(pregunta_area);
        }

        // GET: pregunta_area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta_area pregunta_area = db.pregunta_area.Find(id);
            if (pregunta_area == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area", pregunta_area.fk_area);
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta", pregunta_area.fk_pregunta);
            return View(pregunta_area);
        }

        // POST: pregunta_area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pregunta_area,fk_pregunta,fk_area")] pregunta_area pregunta_area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta_area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_area = new SelectList(db.areas_car, "id_area", "nombre_area", pregunta_area.fk_area);
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta", pregunta_area.fk_pregunta);
            return View(pregunta_area);
        }

        // GET: pregunta_area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta_area pregunta_area = db.pregunta_area.Find(id);
            if (pregunta_area == null)
            {
                return HttpNotFound();
            }
            return View(pregunta_area);
        }

        // POST: pregunta_area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pregunta_area pregunta_area = db.pregunta_area.Find(id);
            db.pregunta_area.Remove(pregunta_area);
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
