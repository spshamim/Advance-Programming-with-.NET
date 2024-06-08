using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace introAgain.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Details(string id)
        {
            ViewData["Name"] = id;
            return View();
        }

        public ActionResult Other()
        {
            return View();
        }
    }
}