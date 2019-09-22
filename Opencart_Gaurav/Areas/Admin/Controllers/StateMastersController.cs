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
    public class StateMastersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Admin/StateMasters
        public ActionResult Index()
        {
            var stateMasters = db.StateMasters.Include(s => s.CountryMaster);
            return View(stateMasters.ToList());
        }

        // GET: Admin/StateMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = db.StateMasters.Find(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // GET: Admin/StateMasters/Create
        public ActionResult Create()
        {
            ViewBag.RefCountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName");
            return View();
        }

        // POST: Admin/StateMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName,RefCountryId")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                db.StateMasters.Add(stateMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RefCountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName", stateMaster.RefCountryId);
            return View(stateMaster);
        }

        // GET: Admin/StateMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = db.StateMasters.Find(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefCountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName", stateMaster.RefCountryId);
            return View(stateMaster);
        }

        // POST: Admin/StateMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName,RefCountryId")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RefCountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName", stateMaster.RefCountryId);
            return View(stateMaster);
        }

        // GET: Admin/StateMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = db.StateMasters.Find(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // POST: Admin/StateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateMaster stateMaster = db.StateMasters.Find(id);
            db.StateMasters.Remove(stateMaster);
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
