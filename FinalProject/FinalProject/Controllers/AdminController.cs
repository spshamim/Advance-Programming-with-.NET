using FinalProject.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}