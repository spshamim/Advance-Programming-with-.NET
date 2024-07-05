using AutoMapper;
using FinalProject.Authorization;
using FinalProject.DTOs;
using FinalProject.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace FinalProject.Controllers
{
    [CustomerAccess]
    public class CustomerController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddItem()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddItem(int id, string Item_Name, decimal Estimated_Price,int Quantity, string Category)
        {
            if (ModelState.IsValid)
            {
                var newItem = new Item
                {
                    List_Id = id,
                    Item_Name = Item_Name,
                    Quantity = Quantity,
                    Category = Category,
                    Estimated_Price = Estimated_Price
                };

                db.Items.Add(newItem);
                db.SaveChanges();

                return RedirectToAction("ViewList");
            }

            TempData["Msg"] = "Not added...";
            return View();
        }

        ////////////////////////////////////////////////////////////////////


        [HttpGet]
        public ActionResult CreateList()
        {
            return View(new ShoppingListDTO());
        }

        [HttpPost]
        public ActionResult CreateList(ShoppingListDTO s)
        {
            var uid = ((User)Session["user"]).User_Id;
            if (ModelState.IsValid)
            {
                var newl = new ShoppingList
                {
                    User_Id = uid,
                    List_Name = s.List_Name,
                    C_Date = s.C_Date,
                };

                db.ShoppingLists.Add(newl);
                db.SaveChanges();

                return RedirectToAction("ViewList");
            }

            TempData["Msg"] = "Not added...";
            return View();
        }

        public ActionResult ViewList()
        {
            var uid = ((User)Session["user"]).User_Id;
            var obbj = (from b in db.ShoppingLists
                       where b.User_Id == uid
                       select b).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
            });
            var mapper = new Mapper(config);
            var slist = mapper.Map<List<ShoppingListDTO>>(obbj);
            return View(slist);
        }

        [HttpGet]
        public ActionResult EditList(int id)
        {
            var exobj = db.ShoppingLists.Find(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
            });
            var mapper = new Mapper(config);
            var dd = mapper.Map<ShoppingListDTO>(exobj);

            return View(dd);
        }

        [HttpPost]
        public ActionResult EditList(ShoppingListDTO dd)
        {
            if (ModelState.IsValid)
            {
                var exobj = db.ShoppingLists.Find(dd.List_Id);
                
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ShoppingListDTO, ShoppingList>();
                });
                var mapper = new Mapper(config);
                var dob = mapper.Map<ShoppingList>(exobj);

                dob.List_Name = dd.List_Name;
                dob.C_Date = DateTime.Now;

                db.SaveChanges();
                TempData["Msg"] = "Edited Successfully...";
                return RedirectToAction("ViewList");

            }
            return View(dd);
        }

        public ActionResult DeleteList(int id)
        {
            var exobj = db.ShoppingLists.Find(id);
            db.ShoppingLists.Remove(exobj);
            db.SaveChanges();
            TempData["Msg"] = "Deleted Successfully...";
            return RedirectToAction("ViewList");
        }

        public ActionResult ListDetails()
        {
            var userId = ((User)Session["user"]).User_Id;

            if (userId == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            var data = db.ShoppingLists
                .Where(oo => oo.User_Id == userId)
                .Include(oo => oo.Items) // nav prop
                .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingList, ShoppingListItemDTO>();
                cfg.CreateMap<Item, ItemDTO>();
            });

            var mapper = new Mapper(config);
            var pd = mapper.Map<List<ShoppingListItemDTO>>(data);
            return View(pd);
        }

        public ActionResult MarkAsBought(int listId, int itemId)
        {
            var shoppingList = db.ShoppingLists.Find(listId);

            if (shoppingList == null)
            {
                return RedirectToAction("ListDetails");
            }

            var item = shoppingList.Items.FirstOrDefault(i => i.Item_Id == itemId);

            if (item == null)
            {
                return RedirectToAction("ListDetails");
            }

            item.IsBought = "Bought";
            db.SaveChanges();

            return RedirectToAction("ListDetails");
        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            var data8 = db.ShoppingLists
                .Where(oo => oo.Items.Any(item => item.Category.Contains(Search)))
                .Include(oo => oo.Items)
                .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingList, ShoppingListItemDTO>();
                cfg.CreateMap<Item, ItemDTO>();
            });

            var mapper = new Mapper(config);
            var df = mapper.Map<List<ShoppingListItemDTO>>(data8);
            return View("ListDetails", df);
        }

    }
}