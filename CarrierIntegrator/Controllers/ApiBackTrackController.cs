using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarrierIntegrator.Services;
using System.Web.Mvc;
using System.Web.Http.Cors;
using CarrierIntegrator.Models;

namespace CarrierIntegrator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiBackTrackController : ApiController
    {
        private CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        //session, carrera ,area
        [System.Web.Http.HttpGet]
        public JsonResult BackTrackRespuesta(int id, int respuesta, int token)
        {
            bool apto = false;
            /*datos para paramas de storage procedures*/
            int id_session = id;
            int id_carrera = respuesta;
            int id_area = token;

            var backtrack = db.spBack_Tracking(id_session, id_area, "SI", id_carrera).ToList();

            return new JsonResult { Data = backtrack, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}
