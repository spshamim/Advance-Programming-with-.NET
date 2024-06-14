using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomValidation.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Students()
        {
            return View();
        }
        public ActionResult Departments()
        {
            return View();
        }
    }
}