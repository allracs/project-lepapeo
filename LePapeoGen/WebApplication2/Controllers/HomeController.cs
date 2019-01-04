using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.Identity.Name == "Admin@mail.com") return RedirectToAction("Admin", "Home");


            /*
             * Es de tipo restauranteEN?
             * return RedirectToAction
             */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Users = "Admin@mail.com")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}