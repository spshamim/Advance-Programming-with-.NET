using ProductMgmtSys.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMgmtSys.Controllers
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