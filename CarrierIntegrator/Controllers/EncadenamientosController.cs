using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrierIntegrator.Controllers
{
    public class EncadenamientosController : Controller
    {
        CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();
        // GET: Encadenamientos
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResultEA(int id)
        {
            var results = db.spConteoArea(id, "SI").Single();
            var areas = db.Carreras.Where(i => i.fk_area == results.idArea).Select(s => new
            {
                id_carrera = s.id_carrera,
                carrera = s.nombre_carrera,
                descripcion = s.descripcion_carrera,
                id_area = s.fk_area,
                area = s.areas_car.nombre_area
            }).ToList();

            return Json(areas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Carrera(int id)
        {
            var carreras = db.Carreras.Where(i => i.id_carrera == id).Select(e => new
            {
                id_carrera = e.id_carrera,
                nombre_carrera = e.nombre_carrera
            });

            return Json(carreras, JsonRequestBehavior.AllowGet);
        }

        //GEt area de carrera
        public ActionResult AreaByCarrera(int id)
        {
            Carreras carrera = db.Carreras.Find(id);
            var carreras = db.areas_car.Where(f => f.id_area == carrera.fk_area).Select(e => new
            {
                id_area = e.id_area,
                nombre_area = e.nombre_area
            });

            return Json(carreras, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PreguntasByArea(int id)
        {
            var preguntas = db.pregunta_area.Where(i => i.fk_area == id).Select(s => new
            {
                id_pregunta = s.fk_pregunta,
                pregunta = s.Preguntas.pregunta,
                id_area = s.fk_area,
                area = s.areas_car.nombre_area
            }).ToList();

            return Json(preguntas , JsonRequestBehavior.AllowGet);
        }

    }
}