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


        /*PREGUTNAS ENCADENAMIENTO HACIA ATRAS*/
        public ActionResult Back(int id)
        {
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

            return Index();
        }
    }
}