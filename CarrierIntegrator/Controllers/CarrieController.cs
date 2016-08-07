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

        public ActionResult LogIn()
        {
            return View();
        }

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

        public ActionResult Main()
        {
            int usersession = 0;
            if (Session["usersession"] != null)
            {
                usersession = Convert.ToInt32(Session["usersession"]);
            }

            return View();
        }

        public ActionResult Back(int id)
        {
            return View();
        }

        public ActionResult Foward()
        {
            return View();
        }
    }
}