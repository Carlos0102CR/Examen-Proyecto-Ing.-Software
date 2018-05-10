using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Traduccion_Viewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Palabras()
        {
            ViewBag.Message = "Palabras.";

            return View();
        }

        public ActionResult Diccionarios()
        {
            ViewBag.Message = "Diccionarios";

            return View();
        }


        public ActionResult Traducciones()
        {
            ViewBag.Message = "Traducciones";

            return View();
        }


        public ActionResult PalabrasPopulares()
        {
            ViewBag.Message = "100 Palabras mas Populares";

            return View();
        }

        public ActionResult PalabrasDisponibles()
        {
            ViewBag.Message = "Idiomas Disponibles";

            return View();
        }

        public ActionResult TraduccionesDisponibles()
        {
            ViewBag.Message = "Traducciones Disponibles";

            return View();
        }
    }
}