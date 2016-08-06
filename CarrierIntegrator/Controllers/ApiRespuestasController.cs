using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Description;
using System.Web.Http.Results;
using CarrierIntegrator.Services;
using System.Web.Mvc;
using System.Web.Http.Cors;
using CarrierIntegrator.Models;


namespace CarrierIntegrator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiRespuestasController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();
        RespuestasService rs;
     

        public ApiRespuestasController()
        {
            rs = new RespuestasService(db);
            
        }
       

        //Obtener las preguntas y las respuestas
        //GET: api/ApiRespuestas/token
        [System.Web.Http.HttpGet]
        public JsonResult TotalRespuestas(int id)
        {
            var en = db.preguntas_en_ad.Where(p => p.id_session == id).Select(e => new
            {
                id_pregunta = e.fk_pregunta,
                respuesta = e.respuesta,
                usuario = e.fk_usuario
            }
           ).ToList();

            return new JsonResult { Data = en, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Mandar las respuestas a las preguntas, una por una
        //GET: api/ApiRespuestas/id_pregunta/respuesta/token
        [System.Web.Http.HttpGet]
        public IHttpActionResult SendedRequest(int? id, string respuesta, int? token)
        {

            if(token == null || respuesta == null || id == null)
            {
                return BadRequest();
            }
            //Buscar las preunas contestadas en la sesion
            var contestadas = from resp in db.preguntas_en_ad where resp.id_session == token select resp;
            if (contestadas.Count() < 80)
            {
                rs.AddRespuesta(Convert.ToInt32(id), respuesta, Convert.ToInt32(token));
            }

            return Ok();
        }

        
    }
}
