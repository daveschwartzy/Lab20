using Lab20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult ProcessSignup(Register Signup)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FirstName = Signup.FirstName;

                return View();
            }
            else
            {
                return View("Signup");
            }
        }
    }
}