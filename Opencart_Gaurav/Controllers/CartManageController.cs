using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Opencart_Gaurav.Models;

namespace Opencart_Gaurav.Controllers
{
    public class CartManageController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: CartManage
        public ActionResult Index()
        {
            var cartMasters = db.CartMasters.Include(c => c.ProductMaster).Include(c => c.UserMaster);
            return View(cartMasters.ToList().Where(a=>a.refUserId==1 && a.OrderProcessed==false));
        }
        public ActionResult ShowOrder()
        {
            var cartMasters = db.CartMasters.Include(c => c.ProductMaster).Include(c => c.UserMaster);
            return View(cartMasters.ToList().Where(a => a.refUserId == 1 && a.OrderProcessed == true));
        }


        // GET: CartManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartMaster cartMaster = db.CartMasters.Find(id);
            if (cartMaster == null)
            {
                return HttpNotFound();
            }
            return View(cartMaster);
        }

        // GET: CartManage/Create
        public ActionResult Create()
        {
            ViewBag.refProductId = new SelectList(db.ProductMasters, "ProductId", "ProductName");
            ViewBag.refUserId = new SelectList(db.UserMasters, "UserId", "userFirstName");
            return View();
        }

        // POST: CartManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartId,Qty,refAdminId,refProductId,Date,refUserId")] CartMaster cartMaster)
        {
            if (ModelState.IsValid)
            {
                db.CartMasters.Add(cartMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.refProductId = new SelectList(db.ProductMasters, "ProductId", "ProductName", cartMaster.refProductId);
            ViewBag.refUserId = new SelectList(db.UserMasters, "UserId", "userFirstName", cartMaster.refUserId);
            return View(cartMaster);
        }

        // GET: CartManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartMaster cartMaster = db.CartMasters.Find(id);
            if (cartMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.refProductId = new SelectList(db.ProductMasters, "ProductId", "ProductName", cartMaster.refProductId);
            ViewBag.refUserId = new SelectList(db.UserMasters, "UserId", "userFirstName", cartMaster.refUserId);
            return View(cartMaster);
        }

        // POST: CartManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartId,Qty,refAdminId,refProductId,Date,refUserId")] CartMaster cartMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.refProductId = new SelectList(db.ProductMasters, "ProductId", "ProductName", cartMaster.refProductId);
            ViewBag.refUserId = new SelectList(db.UserMasters, "UserId", "userFirstName", cartMaster.refUserId);
            return View(cartMaster);
        }

        // GET: CartManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartMaster cartMaster = db.CartMasters.Find(id);
            if (cartMaster == null)
            {
                return HttpNotFound();
            }
            return View(cartMaster);
        }

        // POST: CartManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartMaster cartMaster = db.CartMasters.Find(id);
            db.CartMasters.Remove(cartMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
