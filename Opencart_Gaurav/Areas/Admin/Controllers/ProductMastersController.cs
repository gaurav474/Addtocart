using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Opencart_Gaurav.Models;

namespace Opencart_Gaurav.Areas.Admin.Controllers
{
    public class ProductMastersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Admin/ProductMasters
        public ActionResult Index()
        {
            var productMasters = db.ProductMasters.Include(p => p.SubCategoryMaster);
            return View(productMasters.ToList());
        }

        // GET: Admin/ProductMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // GET: Admin/ProductMasters/Create
        public ActionResult Create()
        {
            ViewBag.RefSubCategoryId = new SelectList(db.SubCategoryMasters, "SubCategoryId", "SubCategoryName");
            return View();
        }

        // POST: Admin/ProductMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,RefSubCategoryId,price,Description,ProductImage")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.ProductMasters.Add(productMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RefSubCategoryId = new SelectList(db.SubCategoryMasters, "SubCategoryId", "SubCategoryName", productMaster.RefSubCategoryId);
            return View(productMaster);
        }

        // GET: Admin/ProductMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefSubCategoryId = new SelectList(db.SubCategoryMasters, "SubCategoryId", "SubCategoryName", productMaster.RefSubCategoryId);
            return View(productMaster);
        }

        // POST: Admin/ProductMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,RefSubCategoryId,price,Description,ProductImage")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RefSubCategoryId = new SelectList(db.SubCategoryMasters, "SubCategoryId", "SubCategoryName", productMaster.RefSubCategoryId);
            return View(productMaster);
        }

        // GET: Admin/ProductMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // POST: Admin/ProductMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductMaster productMaster = db.ProductMasters.Find(id);
            db.ProductMasters.Remove(productMaster);
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
