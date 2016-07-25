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
    public class areas_carController : Controller
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: areas_car
        public ActionResult Index()
        {
            return View(db.areas_car.ToList());
        }

        // GET: areas_car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            areas_car areas_car = db.areas_car.Find(id);
            if (areas_car == null)
            {
                return HttpNotFound();
            }
            return View(areas_car);
        }

        // GET: areas_car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: areas_car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_area,nombre_area,descripcion_area")] areas_car areas_car)
        {
            if (ModelState.IsValid)
            {
                db.areas_car.Add(areas_car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areas_car);
        }

        // GET: areas_car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            areas_car areas_car = db.areas_car.Find(id);
            if (areas_car == null)
            {
                return HttpNotFound();
            }
            return View(areas_car);
        }

        // POST: areas_car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_area,nombre_area,descripcion_area")] areas_car areas_car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areas_car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areas_car);
        }

        // GET: areas_car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            areas_car areas_car = db.areas_car.Find(id);
            if (areas_car == null)
            {
                return HttpNotFound();
            }
            return View(areas_car);
        }

        // POST: areas_car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            areas_car areas_car = db.areas_car.Find(id);
            db.areas_car.Remove(areas_car);
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
