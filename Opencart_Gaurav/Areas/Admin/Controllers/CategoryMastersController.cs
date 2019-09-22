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
    public class CategoryMastersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Admin/CategoryMasters
        public ActionResult Index()
        {
            return View(db.CategoryMasters.ToList());
        }

        // GET: Admin/CategoryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // GET: Admin/CategoryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.CategoryMasters.Add(categoryMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryMaster);
        }

        // GET: Admin/CategoryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: Admin/CategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryMaster);
        }

        // GET: Admin/CategoryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: Admin/CategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            db.CategoryMasters.Remove(categoryMaster);
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
