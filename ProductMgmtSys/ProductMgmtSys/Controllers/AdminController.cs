﻿using AutoMapper;
using ProductMgmtSys.Authentication;
using ProductMgmtSys.DTOs;
using ProductMgmtSys.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace ProductMgmtSys.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        PMSEntities db = new PMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {
            var data = (from order in db.Orders // Retrieving Type From Users Table and Merging with Orders
                        join user in db.Users on order.UserId equals user.Id
                        select new OrderDTO
                        {
                            Id = order.Id,            
                            Status = order.Status,    
                            UserId = order.UserId,    
                            UserType = user.Type,     
                            TotalAmount = order.TotalAmount,
                            OrderDate = order.OrderDate
                        }).ToList();

            return View(data);
        }

        public ActionResult Approve(int id)
        {
            var data = db.Orders.Find(id);
            if (data == null)
            {
                TempData["Msg3"] = "Data not found...";
                return RedirectToAction("Orders");
            }
            else
            {
                var orderproducts = data.OrderProducts;
                foreach (var item in orderproducts)
                {
                    item.Product.Qty -= item.Qty;
                    
                    //var p = db.Products.Find(item.PId);
                    //p.Qty -= item.Qty;
                }

                data.Status = "Accepted";
                db.SaveChanges();
                TempData["Msg4"] = "Order Id " + id + " Accepted Successfully...";
                return RedirectToAction("Orders");
            }
        }

        public ActionResult Decline(int id)
        {
            var data = db.Orders.Find(id);
            if (data == null)
            {
                TempData["Msg3"] = "Data not found...";
                return RedirectToAction("Orders");
            }
            else
            {
                data.Status = "Declined";
                db.SaveChanges();
                TempData["Msg3"] = "Order Id " + id + " Declined Successfully...";
                return RedirectToAction("Orders");
            }
        }

        public ActionResult Od(int id)
        {
            var data = (from dd in db.OrderProducts
                       where dd.OId == id
                       select dd).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderProduct, OrderProductDTO>(); // all will map except ProductDTO property, this is non-primitive
                cfg.CreateMap<Product, ProductDTO>(); // Product to ProductDTO -> non-primitive convert
            });
            var mapper = new Mapper(config);
            var pd = mapper.Map<List<OrderProductDTO>>(data);
            return View(pd);
        }
    }
}