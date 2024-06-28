using ProductMgmtSys.DTOs;
using ProductMgmtSys.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMgmtSys.Controllers
{
    public class LoginController : Controller
    {
        PMSEntities db = new PMSEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var data = (from s in db.Users
                           where (s.Uname.Equals(l.Uname)) && (s.Password.Equals(l.Password))
                           select s).SingleOrDefault();
                if (data == null)
                {
                    TempData["Msg"] = "Username and Password not found...";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (data.Type.Equals("Admin"))
                    {
                        Session["user"] = data;
                        TempData["Msg"] = "Login Successfull...";
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (data.Type.Equals("Customer"))
                    {
                        Session["user"] = data;
                        TempData["Msg"] = "Login Successfull...";
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                    {
                        TempData["Msg"] = "Undefined User Type...";
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(l);
        }

        public ActionResult Logout()
        {
            if (((User)Session["user"]).Type.Equals("Customer"))
            {
                Session["cart"] = null;
            }

            Session["user"] = null;
            TempData["Msg2"] = "Logout Successfull...";
            return RedirectToAction("Index");
        }
    }
}