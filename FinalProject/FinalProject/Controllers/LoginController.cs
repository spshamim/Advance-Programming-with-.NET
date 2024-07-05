using AutoMapper;
using FinalProject.DTOs;
using FinalProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class LoginController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();
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
                            where (s.Username.Equals(l.Uname)) && (s.Password.Equals(l.Password))
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

        [HttpGet]
        public ActionResult SignUp()
        {
            return View(new SignUpDTO());
        }

        [HttpPost]
        public ActionResult SignUp(SignUpDTO s)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<SignUpDTO, User>();
                });
                var mapper = new Mapper(config);
                var aa = mapper.Map<User>(s);

                db.Users.Add(aa);
                db.SaveChanges();

                TempData["Msg2"] = "Sign Up Successfull..";
                return RedirectToAction("Index");
            }

            return View(s);
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            TempData["Msg"] = "Logout Successfull...";
            return RedirectToAction("Index");
        }
    }
}