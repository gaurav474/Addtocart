using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Opencart_Gaurav.Models;

namespace Opencart_Gaurav.Controllers
{
    public class SearchProductController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        // GET: SearchProduct
        public ActionResult Index( string productname="")
        {
            if(productname=="empty")
            {
                return View(db.ProductMasters);
            }

            var data = db.ProductMasters.Where(a => a.ProductName.Contains(productname));
            return View();
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            return View(db.ProductMasters.Find("id"));
        }

        [HttpPost]

        public ActionResult AddToCart(int id ,int quantity)
        {
            CartMaster ct = new CartMaster();
            ct.Date = DateTime.Now;
            ct.refProductId = id;
            ct.Qty = quantity;
            ct.refUserId = 1;



            db.CartMasters.Add(ct);
            db.SaveChanges();

            return View(ct);
        }
    }
}