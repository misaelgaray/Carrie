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
using CarrierIntegrator.Models;
using System.Web.Http.Cors;

namespace CarrierIntegrator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApisessionsController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: api/Apisessions
        public JsonResult Getsession()
        {
            
            //By default session is Misaels Session
            Tsession new_session = StaticObjects.session(1, DateTime.Now);
            db.Tsession.Add(new_session);

            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw;
            }

            var result = (from sess in db.Tsession select sess.id_session).Max();

            return new JsonResult { Data = new {token = result}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Get: api/Apisession/user/pass
        public JsonResult GetUserSession(string id, string respuesta)
        {
            var login = (from log in db.Usuarios where log.correo_usuario == id && log.pass_usuario == respuesta select log).Single();

            if(login == null)
            {
                return new JsonResult { Data = new { token = false } , JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
            

            Tsession new_session = StaticObjects.session(login.id_usuario, DateTime.Now);
            db.Tsession.Add(new_session);

            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw;
            }

            var result = (from sess in db.Tsession select sess.id_session).Max();

            return new JsonResult { Data = new { token = result }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


       

        // GET: api/Apisessions/5
        [ResponseType(typeof(session))]
        public IHttpActionResult Getsession(int id)
        {
            session session = db.session.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

      /*  // PUT: api/Apisessions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsession(int id, session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.id_session)
            {
                return BadRequest();
            }

            db.Entry(session).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sessionExists(id))
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

        // POST: api/Apisessions
        [ResponseType(typeof(session))]
        public IHttpActionResult Postsession(session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.session.Add(session);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = session.id_session }, session);
        }

        // DELETE: api/Apisessions/5
        [ResponseType(typeof(session))]
        public IHttpActionResult Deletesession(int id)
        {
            session session = db.session.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            db.session.Remove(session);
            db.SaveChanges();

            return Ok(session);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sessionExists(int id)
        {
            return db.session.Count(e => e.id_session == id) > 0;
        }*/
    }
}