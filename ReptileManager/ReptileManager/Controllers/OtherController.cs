using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReptileManager.Models;

namespace ReptileManager.Controllers
{
    public class OtherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Other
        public ActionResult Index()
        {
            var other = db.Other.Include(o => o.Reptile);
            return View(other.ToList());
        }

        // GET: Other/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other other = db.Other.Find(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            return View(other);
        }
        /*
        // in reptiles class
        // GET: Other/Create
        public ActionResult Create()
        {
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName");
            return View();
        }

        // POST: Other/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OtherId,Date,Newaction,Notes,ReptileId")] Other other)
        {
            if (ModelState.IsValid)
            {
                db.Other.Add(other);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", other.ReptileId);
            return View(other);
        }
         * */

        // GET: Other/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other other = db.Other.Find(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", other.ReptileId);
            return View(other);
        }

        // POST: Other/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OtherId,Date,Newaction,Notes,ReptileId")] Other other)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", other.ReptileId);
            return View(other);
        }

        // GET: Other/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other other = db.Other.Find(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            return View(other);
        }

        // POST: Other/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Other other = db.Other.Find(id);
            db.Other.Remove(other);
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
