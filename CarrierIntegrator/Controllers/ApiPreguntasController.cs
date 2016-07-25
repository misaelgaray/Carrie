using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarrierIntegrator;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CarrierIntegrator.Controllers
{
    public class ApiPreguntasController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: api/ApiPreguntas
        public JsonResult GetPreguntas()
        {
            var emp = db.Preguntas.Select(e => new
            {
                id = e.id_pregunta,
                pregunta = e.pregunta
            }
            ).ToList();

            return new JsonResult { Data = emp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        
        // GET: api/ApiPreguntas/5
        [ResponseType(typeof(Preguntas))]
        public IHttpActionResult GetPreguntas(int id)
        {
            Preguntas preguntas = db.Preguntas.Find(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            return Ok(preguntas);
        }

        // PUT: api/ApiPreguntas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreguntas(int id, Preguntas preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntas.id_pregunta)
            {
                return BadRequest();
            }

            db.Entry(preguntas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
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