using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our Travel Company";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please feel free to contact us";

            return View();
        }
    }
}