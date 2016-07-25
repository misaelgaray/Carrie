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
    public class preguntas_en_adController : Controller
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: preguntas_en_ad
        public ActionResult Index()
        {
            var preguntas_en_ad = db.preguntas_en_ad.Include(p => p.Preguntas).Include(p => p.Usuarios).Include(p => p.Tsession);
            return View(preguntas_en_ad.ToList());
        }

        // GET: preguntas_en_ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            preguntas_en_ad preguntas_en_ad = db.preguntas_en_ad.Find(id);
            if (preguntas_en_ad == null)
            {
                return HttpNotFound();
            }
            return View(preguntas_en_ad);
        }

        // GET: preguntas_en_ad/Create
        public ActionResult Create()
        {
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta");
            ViewBag.fk_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario");
            ViewBag.id_session = new SelectList(db.Tsession, "id_session", "id_session");
            return View();
        }

        // POST: preguntas_en_ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_respuesta,fk_pregunta,fk_usuario,respuesta,id_session")] preguntas_en_ad preguntas_en_ad)
        {
            if (ModelState.IsValid)
            {
                db.preguntas_en_ad.Add(preguntas_en_ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta", preguntas_en_ad.fk_pregunta);
            ViewBag.fk_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", preguntas_en_ad.fk_usuario);
            ViewBag.id_session = new SelectList(db.Tsession, "id_session", "id_session", preguntas_en_ad.id_session);
            return View(preguntas_en_ad);
        }

        // GET: preguntas_en_ad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            preguntas_en_ad preguntas_en_ad = db.preguntas_en_ad.Find(id);
            if (preguntas_en_ad == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta", preguntas_en_ad.fk_pregunta);
            ViewBag.fk_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", preguntas_en_ad.fk_usuario);
            ViewBag.id_session = new SelectList(db.Tsession, "id_session", "id_session", preguntas_en_ad.id_session);
            return View(preguntas_en_ad);
        }

        // POST: preguntas_en_ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_respuesta,fk_pregunta,fk_usuario,respuesta,id_session")] preguntas_en_ad preguntas_en_ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntas_en_ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_pregunta = new SelectList(db.Preguntas, "id_pregunta", "pregunta", preguntas_en_ad.fk_pregunta);
            ViewBag.fk_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", preguntas_en_ad.fk_usuario);
            ViewBag.id_session = new SelectList(db.Tsession, "id_session", "id_session", preguntas_en_ad.id_session);
            return View(preguntas_en_ad);
        }

        // GET: preguntas_en_ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            preguntas_en_ad preguntas_en_ad = db.preguntas_en_ad.Find(id);
            if (preguntas_en_ad == null)
            {
                return HttpNotFound();
            }
            return View(preguntas_en_ad);
        }

        // POST: preguntas_en_ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            preguntas_en_ad preguntas_en_ad = db.preguntas_en_ad.Find(id);
            db.preguntas_en_ad.Remove(preguntas_en_ad);
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
