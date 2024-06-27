using AutoMapper;
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
    [CustomerAccess]
    public class OrderController : Controller
    {
        PMSEntities db = new PMSEntities();
        public ActionResult Index()
        {
            var data = db.Products.ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var pd = mapper.Map<List<ProductDTO>>(data);
            return View(pd);
        }

        public ActionResult addtocart(int id)
        {
            var exobj = db.Products.Find(id); // EF Class Object

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var dobj = mapper.Map<ProductDTO>(exobj); // EF class to DTO class

            dobj.Qty = 1; // override the Quantity (because Qty coming from DB)
            var cart = new List<ProductDTO>(); // initializing a new list of ProductDTO class object (only one time)
            if (Session["cart"] == null)
            {
                cart.Add(dobj);
                Session["cart"] = cart;
            }
            else
            {
                var data = (List<ProductDTO>)Session["cart"]; // destructuring to add another object in the list
                var existingProduct = data.FirstOrDefault(p => p.Name == dobj.Name);

                if (existingProduct != null)
                {
                    existingProduct.Qty += 1; // increase the quantity if the product already exists
                }
                else
                {
                    data.Add(dobj); // add new product if it doesn't exist
                }

                Session["cart"] = data;
            }
            TempData["Msg"] = dobj.Name + " - Added to Cart Successfully...";
            return RedirectToAction("Index");
        }


        public ActionResult Cart()
        {
            if (Session["cart"] == null)
            {
                TempData["Msg"] = "Cart is Empty..";
                return RedirectToAction("Index");
            }

            var data = (List<ProductDTO>)Session["cart"]; // destructuring the object
            return View(data);
        }

        public ActionResult placeorder()
        {
            var order = new Order(); // creating order class(EF) obj to store data in database
            order.OrderDate = DateTime.Now;
            if (Session["tt"] == null)
            {
                order.TotalAmount = 0;
            }
            else
            {
                order.TotalAmount = (decimal)Session["tt"];
            }
            order.Status = "Ordered";
            order.UserId = ((User)Session["user"]).Id; // TypeCasting Session to User(EF) Class then accessing the ID

            db.Orders.Add(order);
            db.SaveChanges();

            var data = (List<ProductDTO>)Session["cart"];
            foreach (var p in data)
            {
                var op = new OrderProduct();
                op.Qty = p.Qty;
                op.PId = p.Id;
                op.OId = order.Id;
                op.UnitPrice = p.Price;
                db.OrderProducts.Add(op);
            }
            db.SaveChanges();
            Session["cart"] = null;
            Session["tt"] = null;
            TempData["Msg"] = "Order Placed Successfully...";
            return RedirectToAction("Index");
        }
    }
}