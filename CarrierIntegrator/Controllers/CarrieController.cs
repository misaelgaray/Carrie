using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrierIntegrator.Controllers
{
    public class CarrieController : Controller
    {
        // GET: Carrie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
    }
}