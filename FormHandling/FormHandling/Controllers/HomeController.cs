using FormHandling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormHandling.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login()); // empty object when no value is posting
        }

        [HttpPost]
        public ActionResult Login(Login logi)
        {

            /*if(logi.Uname.Equals("shamim") && logi.Pass.Equals("1234"))
            {
                return RedirectToAction("Index","Dashboard"); // (action, controller)
            }*/

            if(ModelState.IsValid)
            {
                TempData["Msg2"] = "Authorization Successful..";
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                ViewBag.Msg = "Unauthorized access! Permission denied!";
            }

            return View(logi); // need to catch that in view by 'Model' name (retrieving value)
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(new SignUp());
        }

        [HttpPost]
        public ActionResult Signup(SignUp sign)
        {
            if (ModelState.IsValid)
            {
                TempData["Smg2"] = "Sign Up Success...!";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Smg"] = "Sign Up Failed!";
            }

            return View(sign);
        }
    }
}