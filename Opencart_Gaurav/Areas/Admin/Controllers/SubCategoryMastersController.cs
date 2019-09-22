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
    public class SubCategoryMastersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Admin/SubCategoryMasters
        public ActionResult Index()
        {
            var subCategoryMasters = db.SubCategoryMasters.Include(s => s.CategoryMaster);
            return View(subCategoryMasters.ToList());
        }

        // GET: Admin/SubCategoryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // GET: Admin/SubCategoryMasters/Create
        public ActionResult Create()
        {
            ViewBag.RefCategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/SubCategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryId,SubCategoryName,RefCategoryId")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.SubCategoryMasters.Add(subCategoryMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RefCategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", subCategoryMaster.RefCategoryId);
            return View(subCategoryMaster);
        }

        // GET: Admin/SubCategoryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefCategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", subCategoryMaster.RefCategoryId);
            return View(subCategoryMaster);
        }

        // POST: Admin/SubCategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryId,SubCategoryName,RefCategoryId")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoryMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RefCategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", subCategoryMaster.RefCategoryId);
            return View(subCategoryMaster);
        }

        // GET: Admin/SubCategoryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // POST: Admin/SubCategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            db.SubCategoryMasters.Remove(subCategoryMaster);
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
