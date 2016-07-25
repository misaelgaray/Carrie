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
using CarrierIntegrator.Models;

namespace CarrierIntegrator.Controllers
{
    public class ApiUsuariosController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        // GET: api/ApiUsuarios
        /* public IQueryable<Usuarios> GetUsuarios()
         {
             return db.Usuarios;
         }*/
      
        public IHttpActionResult GetUsuarios(int id)
        {

            return Ok();
        }

        // GET: api/ApiUsuarios/5
       
        public IHttpActionResult GetUsuarios(string id_pregunta, string respuesta, string token)
        {

            Usuarios new_user = StaticObjects.NewUsuarios(id_pregunta, respuesta, token);
            db.Usuarios.Add(new_user);

            try
            {
                db.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/ApiUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.id_usuario)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/ApiUsuarios
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.id_usuario }, usuarios);
        }

        // DELETE: api/ApiUsuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.id_usuario == id) > 0;
        }
    }
}