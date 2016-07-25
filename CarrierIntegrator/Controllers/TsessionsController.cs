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
    public class TsessionsController : Controller
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: Tsessions
        public ActionResult Index()
        {
            var tsession = db.Tsession.Include(t => t.Usuarios);
            return View(tsession.ToList());
        }

        // GET: Tsessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tsession tsession = db.Tsession.Find(id);
            if (tsession == null)
            {
                return HttpNotFound();
            }
            return View(tsession);
        }

        // GET: Tsessions/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Tsessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_session,id_usuario,fecha_sesion")] Tsession tsession)
        {
            if (ModelState.IsValid)
            {
                db.Tsession.Add(tsession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", tsession.id_usuario);
            return View(tsession);
        }

        // GET: Tsessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tsession tsession = db.Tsession.Find(id);
            if (tsession == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", tsession.id_usuario);
            return View(tsession);
        }

        // POST: Tsessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_session,id_usuario,fecha_sesion")] Tsession tsession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tsession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", tsession.id_usuario);
            return View(tsession);
        }

        // GET: Tsessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tsession tsession = db.Tsession.Find(id);
            if (tsession == null)
            {
                return HttpNotFound();
            }
            return View(tsession);
        }

        // POST: Tsessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tsession tsession = db.Tsession.Find(id);
            db.Tsession.Remove(tsession);
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
