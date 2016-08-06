using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace CarrierIntegrator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiPregAppController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();
        // GET: api/ApiPreguntas
        public JsonResult GetPreguntas(int id)
        {

            List<pregunta_area> pa = new List<pregunta_area>();

            for (int i = 1; i < 6; i++)
            {
                var pba = from preg in db.pregunta_area where preg.fk_area == i select preg;
                int cont = 1;
                foreach (var pregunta in pba)
                {
                    if(cont == id +4)
                    {
                        break;
                    }
                    pa.Add(pregunta);
                    cont++;
                }
            }

            var emp = pa.Select( i => new
            {
                id_pregunta = i.fk_pregunta,
                pregunta = i.Preguntas.pregunta,
                id_area = i.fk_area,
                area = i.areas_car.nombre_area
            }
                );

            return new JsonResult { Data = emp, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
