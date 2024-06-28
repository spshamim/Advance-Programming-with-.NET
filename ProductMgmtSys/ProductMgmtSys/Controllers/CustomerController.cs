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
    [CustomerAccess]
    public class CustomerController : Controller
    {
        PMSEntities db = new PMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index","Login");
            }

            var userid = (User)Session["user"];
            var data = (from order in db.Orders
                       where order.UserId == userid.Id
                       select order).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            var ood = mapper.Map<List<OrderDTO>>(data);
            return View(ood);
        }

        public ActionResult Cancel(int id)
        {
            var data = db.Orders.Find(id);
            if (data == null)
            {
                TempData["Msg3"] = "Data not found...";
                return RedirectToAction("Orders");
            }
            else
            {
                data.Status = "Canceled";
                db.SaveChanges();
                TempData["Msg3"] = "Order Canceled Successfully...";
                return RedirectToAction("Orders");
            }
        }
    }
}