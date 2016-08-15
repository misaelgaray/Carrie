using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarrierIntegrator.Services;

namespace CarrierIntegrator.Controllers
{
    public class CarrieController : Controller
    {
        CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();
        SessionService ss = new SessionService();
        // GET: Carrie
        public ActionResult Index()
        {
            return View();

            var it = db.spBack_Tracking(1,2,"SI",3);
            
            
        }

        /*Renderizar Login*/
        public ActionResult LogIn()
        {
            return View();
        }

        /*PETICIONES AJAX*/
        [HttpGet]
        public ActionResult Areas()
        {
            var carreras = db.areas_car.Select(e => new
            {
                id_area = e.id_area,
                nombre_area = e.nombre_area
            });

            return Json(carreras, JsonRequestBehavior.AllowGet);
        }

        /*PETICIONES AJAX*/
        [HttpGet]
        public ActionResult Carreras(int id)
        {
            var carreras = db.Carreras.Where(i => i.fk_area == id).Select(e => new
            {
                id_carrera = e.id_carrera,
                nombre_carrera = e.nombre_carrera
            });

            return Json(carreras, JsonRequestBehavior.AllowGet);
        }

        /*VALIDAR INICIO SESINO*/
        [HttpPost]
        public ActionResult LogIn(string email, string pass)
        {
            if(email == null || pass == null)
            {
                TempData["login"] = "void";
                return RedirectToAction("LogIn");
            }

            int validado = ss.LogIn(email, pass);
            Session["usersession"] = validado;

            if (validado != 0)
            {
                TempData["login"] = "success";
                return RedirectToAction("Main");
            }

            TempData["login"] = "denied";
            return RedirectToAction("LogIn");
        }

        /*VALIDAR INICIO SESINO*/
        [HttpPost]
        public ActionResult LogOn(string userr, string emailr, string passr)
        {
            if (emailr == null || passr == null || userr == null)
            {
                TempData["login"] = "void";
                return RedirectToAction("LogIn");
            }


            int validado = ss.LogOn(userr, emailr, passr);
            Session["usersession"] = validado;

            if (validado != 0)
            {
                TempData["login"] = "success";
                return RedirectToAction("Main");
            }

            TempData["login"] = "denied";
            return RedirectToAction("LogIn");
        }

        /*SECCION SE O NO SE QUE ESTUDIAR*/
        public ActionResult Main()
        {
            if (Session["usersession"] == null)
            {
                TempData["login"] = "session";
                return RedirectToAction("LogIn");
            }
            int usersession = 0;
            usersession = Convert.ToInt32(Session["usersession"]);
            return View();
        }


        /*PREGUTNAS ENCADENAMIENTO HACIA ATRAS recibe como id la carrera*/
        public ActionResult Back(int id)
        {
            if (Session["usersession"] == null)
            {
                TempData["login"] = "session";
                return RedirectToAction("LogIn");
            }

            Session["carrera"] = id; 
            //Buscamos el id del area dependiendo la carrera
            Carreras id_area = db.Carreras.Find(id);

            var cantidad_preguntas = (from canti in db.pregunta_area where canti.fk_area == id_area.fk_area select canti).Count();
            ViewBag.cantidad_preguntas = cantidad_preguntas;
            ViewBag.session = Session["usersession"];
            ViewBag.carrera = id_area.fk_area;
            return View();
        }

        /*PREGUTNAs ENCADENAMIENTO HACIA ADELANTE*/
        public ActionResult Foward()
        {
            if(Session["usersession"] == null)
            {
                TempData["login"] = "session";
                return RedirectToAction("LogIn");
            }

            ViewBag.session = Session["usersession"];
            return View();
        }

        /*CIERRE de VARIABLE DE SESSION*/
        public ActionResult LogOut()
        {
            if (Session["usersession"] == null)
            {
                TempData["login"] = "session";
                return RedirectToAction("LogIn");
            }

            Session["usersession"] = null;
            return RedirectToAction("LogIn");
        }

        /*RESULTADOS DE ENCADENAMIENTO HACIA ADELANTE*/
        public ActionResult ResultsEA()
        {
            if (Session["usersession"] == null)
            {
                TempData["login"] = "session";
                return RedirectToAction("LogIn");
            }
            var results = db.spConteoArea(Convert.ToInt32(Session["usersession"]), "SI").Single();
            var areas = db.Carreras.Where(i => i.fk_area == results.idArea);

            return View(areas.ToList());
        }

        /*Resultados encadenamiento hacia atras*/
        public ActionResult ResultsEB()
        {
            if (Session["usersession"] == null || Session["carrera"] == null)
            {
                TempData["login"] = "session";
                return RedirectToAction("LogIn");
            }
            bool apto = false;
            /*datos para paramas de storage procedures*/
            int id_session = Convert.ToInt32(Session["usersession"]);
            int id_carrera = Convert.ToInt32(Session["carrera"]);
            Carreras carrera = db.Carreras.Find(id_carrera);

            List<spBack_Tracking_Result> backtrack = db.spBack_Tracking(id_session,carrera.fk_area,"SI",id_carrera).ToList();
            if (backtrack[0].idCarrera == id_carrera)
            {
                apto = true;
            }
            var retro = db.spRetroalimientacionCarreras(carrera.fk_area, backtrack[0].idCarrera);

            ViewBag.retroalimentacion = retro;
            ViewBag.aptitud = apto;
            return View(backtrack);
        }
    }
}