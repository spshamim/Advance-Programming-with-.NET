using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFLabTask.EF;
using EFLabTask.DTOs;

namespace EFLabTask.Controllers
{
    public class CourseController : Controller
    {
        private TestEFEntities db = new TestEFEntities();
        public ActionResult Index()
        {
            var data = db.Courses.ToList();
            var converted = Convert(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseDTO c)
        {
            if (ModelState.IsValid)
            {
                var cc = Convert(c);
                db.Courses.Add(cc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Courses.Find(id);
            var dto = Convert(exobj);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Edit(CourseDTO s)
        {
            if (ModelState.IsValid)
            {
                var exobj = db.Courses.Find(s.Id);
                if (exobj != null)
                {
                    exobj.Title = s.Title;
                    exobj.CrdtHr = s.CrdtHr;
                    exobj.Type = s.Type;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(s);
        }

        public ActionResult Delete(int id)
        {
            var exobj = db.Courses.Find(id);
            db.Courses.Remove(exobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            var data = (from c in db.Courses
                        where c.Title.Contains(Search)
                        select c).ToList();

            return View("Index", Convert(data));
        }

        public ActionResult Details(int id)
        {
            var exobj = db.Courses.Find(id);
            var dto = Convert(exobj);
            return View(dto);
        }

        /* ###################################################################################### */

        public static CourseDTO Convert(Cours s) // Input EF -> Output DTO
        {
            return new CourseDTO()
            { 
                Id = s.Id,
                Title = s.Title,
                CrdtHr = s.CrdtHr,
                Type = s.Type
            };
        }

        public static Cours Convert(CourseDTO s) // // Input DTO -> Output EF
        {
            return new Cours()
            {
                Id = s.Id,
                Title = s.Title,
                CrdtHr = s.CrdtHr,
                Type = s.Type
            };
        }

        public static List<CourseDTO> Convert(List<Cours> students)
        {
            var list = new List<CourseDTO>();
            foreach (var c in students)
            {
                var cc = Convert(c);
                list.Add(cc);
            }
            return list;
        }

    }
}