using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarrierIntegrator;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Http.Cors;
using System.Web.Helpers;
using CarrierIntegrator.Models;

namespace CarrierIntegrator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiPreguntasController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: api/ApiPreguntas
        public JsonResult GetPreguntas()
        {
            var emp = db.pregunta_area.Select(e => new
            {
                id_pregunta = e.fk_pregunta,
                pregunta = e.Preguntas.pregunta,
                id_area = e.fk_area,
                area = e.areas_car.nombre_area
            }
            ).ToList();

           
            return new JsonResult{Data = emp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        
        public JsonResult GetPreguntas(int id)
        {
            var emp = db.pregunta_area.Where(i => i.fk_pregunta == id).Select(e => new
            {
                id_pregunta = e.fk_pregunta,
                pregunta = e.Preguntas.pregunta,
                id_area = e.fk_area,
                area = e.areas_car.nombre_area
            }
           ).ToList();


            return new JsonResult { Data = emp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        

        // POST: api/ApiPreguntas
        [ResponseType(typeof(Preguntas))]
        public IHttpActionResult PostPreguntas(Preguntas preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preguntas.Add(preguntas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preguntas.id_pregunta }, preguntas);
        }

        // DELETE: api/ApiPreguntas/5
        [ResponseType(typeof(Preguntas))]
        public IHttpActionResult DeletePreguntas(int id)
        {
            Preguntas preguntas = db.Preguntas.Find(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            db.Preguntas.Remove(preguntas);
            db.SaveChanges();

            return Ok(preguntas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntasExists(int id)
        {
            return db.Preguntas.Count(e => e.id_pregunta == id) > 0;
        }
    }
}