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
using System.Web.Helpers;
using System.Web.Http.Cors;
using CarrierIntegrator.Models;

namespace CarrierIntegrator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PreguntasController : Controller
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        RespuestasService rs = new RespuestasService();

        // GET: Preguntas
        public ActionResult Index()
        {
            return View(db.Preguntas.ToList());
        }

        [HttpGet]
        public JsonResult Preguntas()
        {
            var emp = db.pregunta_area.Select(e => new
            {
                id = e.fk_pregunta,
                pregunta = e.Preguntas.pregunta,
                area = e.fk_area
            }
            ).ToList();

            return new JsonResult { Data = emp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        
        /*public JsonResult TotalRespuestas()
        {
            var en = rs.EncadenamientoAdelante(1).ToList();
            return new JsonResult { Data = en, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }*/

        [HttpGet]
        public ActionResult PreguntasById(int id)
        {
            var emp = db.pregunta_area.Where(i => i.fk_pregunta == id).Select(e => new
            {
                id = e.fk_pregunta,
                pregunta = e.Preguntas.pregunta,
                area = e.fk_area
            }
            ).ToList();

            return Json(emp, JsonRequestBehavior.AllowGet );
        }

        // GET: Preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas preguntas = db.Preguntas.Find(id);
            if (preguntas == null)
            {
                return HttpNotFound();
            }
            return View(preguntas);
        }

        // GET: Preguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pregunta,pregunta")] Preguntas preguntas)
        {
            if (ModelState.IsValid)
            {
                db.Preguntas.Add(preguntas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preguntas);
        }

        // GET: Preguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas preguntas = db.Preguntas.Find(id);
            if (preguntas == null)
            {
                return HttpNotFound();
            }
            return View(preguntas);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pregunta,pregunta")] Preguntas preguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preguntas);
        }

        // GET: Preguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas preguntas = db.Preguntas.Find(id);
            if (preguntas == null)
            {
                return HttpNotFound();
            }
            return View(preguntas);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preguntas preguntas = db.Preguntas.Find(id);
            db.Preguntas.Remove(preguntas);
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
