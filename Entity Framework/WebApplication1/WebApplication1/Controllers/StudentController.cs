﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.EF;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private TestEFEntities db = new TestEFEntities();
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentDTO s)
        {
            if (ModelState.IsValid)
            {
                var st = new Student()
                {
                    Name = s.First_Name.Trim() + " " + s.Last_Name.Trim(),
                    Email = s.Email,
                    Phone = s.Phone,
                    Address = s.Address
                }; // mapping with EF class

                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(s); // to retain value if validation error exist 
        }

        [HttpGet]
        public ActionResult Edit(int id) // int id coming from URL parameter
        {
            var exobj = db.Students.Find(id);
            return View(exobj);
        }

        [HttpPost]
        public ActionResult Edit(Student s) // using entity framework created class
        {
            var exobj = db.Students.Find(s.Id);
            exobj.Address = s.Address;
            exobj.Name = s.Name;
            exobj.Phone = s.Phone;
            exobj.Email = s.Email;

            //caution in using this method
            //db.Entry(exobj).CurrentValues.SetValues(s);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) // int id coming from URL parameter
        {
            var exobj = db.Students.Find(id); 
            db.Students.Remove(exobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string Search) // receiving form data using method binding process
        {
            var data = (from s in db.Students
                        where s.Email.Contains(Search)
                        select s).ToList(); // LINQ QUERY
            //.Single() - if single object need

            //using same view for multiple puposes

            return View("Index", data); // again showing the Index view with the data Model
        }

    }
}