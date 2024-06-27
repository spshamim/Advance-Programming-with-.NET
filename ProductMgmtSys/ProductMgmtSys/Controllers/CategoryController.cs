using AutoMapper;
using ProductMgmtSys.Authentication;
using ProductMgmtSys.DTOs;
using ProductMgmtSys.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMgmtSys.Controllers
{
    [AdminAccess]
    public class CategoryController : Controller
    {
        PMSEntities db = new PMSEntities();
        public ActionResult Index()
        {
            var data = db.Categories.ToList(); // return EF Class Object

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>(); // Convert EF Class to DTO Class
            });
            var mapper = new Mapper(config);
            var cd = mapper.Map<List<CategoryDTO>>(data); // return a object list of DTO Class
            return View(cd);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Categories.Find(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var cd = mapper.Map<CategoryDTO>(exobj);
            return View(cd);
        }

        [HttpPost]
        public ActionResult Edit(CategoryDTO c)
        {
            var exobj = db.Categories.Find(c.Id);
            if (ModelState.IsValid)
            {
                exobj.Name = c.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exobj);
        }
    }
}