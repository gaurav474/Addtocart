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
    public class CityMastersController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Admin/CityMasters
        public ActionResult Index()
        {
            var cityMasters = db.CityMasters.Include(c => c.StateMaster);
            return View(cityMasters.ToList());
        }

        // GET: Admin/CityMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMaster cityMaster = db.CityMasters.Find(id);
            if (cityMaster == null)
            {
                return HttpNotFound();
            }
            return View(cityMaster);
        }

        // GET: Admin/CityMasters/Create
        public ActionResult Create()
        {
            ViewBag.RefStateId = new SelectList(db.StateMasters, "StateId", "StateName");
            return View();
        }

        // POST: Admin/CityMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName,RefStateId")] CityMaster cityMaster)
        {
            if (ModelState.IsValid)
            {
                db.CityMasters.Add(cityMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RefStateId = new SelectList(db.StateMasters, "StateId", "StateName", cityMaster.RefStateId);
            return View(cityMaster);
        }

        // GET: Admin/CityMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMaster cityMaster = db.CityMasters.Find(id);
            if (cityMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefStateId = new SelectList(db.StateMasters, "StateId", "StateName", cityMaster.RefStateId);
            return View(cityMaster);
        }

        // POST: Admin/CityMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName,RefStateId")] CityMaster cityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RefStateId = new SelectList(db.StateMasters, "StateId", "StateName", cityMaster.RefStateId);
            return View(cityMaster);
        }

        // GET: Admin/CityMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMaster cityMaster = db.CityMasters.Find(id);
            if (cityMaster == null)
            {
                return HttpNotFound();
            }
            return View(cityMaster);
        }

        // POST: Admin/CityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityMaster cityMaster = db.CityMasters.Find(id);
            db.CityMasters.Remove(cityMaster);
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
