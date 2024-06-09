using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {

        [HttpGet] 
        public ActionResult Create() // by default this method can be used for http get and post both
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student st)
        {
            ViewBag.Name = st.Name;
            ViewBag.Email = st.Email;
            ViewBag.Profession = st.Profession;
            ViewBag.Gender = st.Gender;
            ViewBag.Hobbies = st.Hobbies;
            return View();
        }

        /*
            annotation - behind the scene logic works
            to eliminate ambiguity we use annotation like [Httpget, HttpPost]
            creating separate method for POST (.NET suggest)
        */

        /* (i) = HTTP Request Based Class
        [HttpPost]
        public ActionResult Create()
        {
            Request["Name"] // Match attrib. with Form attrib.
            Request["Email"]
            return View();
        }

        /* (ii) = Form Collection Object
        [HttpPost]
        public ActionResult Create(FormCollection fc) // works only MVC framework
        {
            fc["Name"] // Match attrib. with Form attrib.
            fc["Name"]
            fc["Name"]
            return View();
        }
        */

        /* (iii) = Variable Name Mapping
        [HttpPost]
        public ActionResult Create(string Name, string Email) // Match attrib. with Form attrib.
        {
            return View();
        }
        */

        /* (iv) = Model Binding
        [HttpPost]
        public ActionResult Create(Student s) //Create a Class inside Model
        {
            return View();
        }
        */
    }
}