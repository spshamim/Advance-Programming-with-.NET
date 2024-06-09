using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Info inff = new Info()
            {
                Name = "Md. Shahriar Parvez Shamim",
                Email = "21-44998-2@student.aiub.edu",
                Phone = "017XXXXXYYY",
                Degree = "BSc. in CSE",
                Expertise = "Javascript, PHP, .NET"
            };
                
            ViewBag.Inff = new Info[] { inff };
            return View();
        }

        public ActionResult Education()
        {
            Education hsc = new Education()
            {
                Year = 2019,
                Group = "Science",
                Institute = "XXX YYYY ZZZ"
            };

            Education ssc = new Education()
            {
                Year = 2017,
                Group = "Science",
                Institute = "ZZZ KKK MMM"
            };

            ViewBag.edu = new Education[] { hsc, ssc };

            return View();
        }

        public ActionResult Projects()
        {
            Project p1 = new Project()
            {
                Title = "Hospital Management System",
                Desc = "XXX YYY ZZZ KKK LLL MMM",
                Course = "OOP1"
            };

            Project p2 = new Project()
            {
                Title = "Service Management in Local Area",
                Desc = "XXX YYY ZZZ KKK LLL MMM",
                Course = "OOP2"
            };

            Project p3 = new Project()
            {
                Title = "Mouse Controll Through Eye Movement",
                Desc = "XXX YYY ZZZ KKK LLL MMM",
                Course = "HCI"
            };

            Project p4 = new Project()
            {
                Title = "Cancer Detection Using Image Processing",
                Desc = "XXX YYY ZZZ KKK LLL MMM",
                Course = "ML"
            };

            Project p5 = new Project()
            {
                Title = "Job Portal",
                Desc = "XXX YYY ZZZ KKK LLL MMM",
                Course = "Web Tech"
            };

            ViewBag.pr = new Project[] { p1,p2,p3,p4,p5 };
            return View();
        }

        public ActionResult References()
        {
            Ref r1 = new Ref()
            {
                Name = "XXX YYY ZZZ",
                Desig = "Professor, Dept. of FST , AIUB"
            };

            Ref r2 = new Ref()
            {
                Name = "KKLL HHHJJK",
                Desig = "Asst. Prof., Dept. of FST , AIUB"
            };

            Ref r3 = new Ref()
            {
                Name = "KOOOO PPPP FF",
                Desig = "Professor, Dept. of FST , AIUB"
            };

            ViewBag.reff = new Ref[] { r1,r2,r3 };
            return View();
        }

        public ActionResult Certificates()
        {

            return View();
        }
    }
}