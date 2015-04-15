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
    public class FeedingsController : Controller
    {
        private ReptileContext db = new ReptileContext();

        // GET: Feedings
        public ActionResult Index()
        {
            var feedings = db.Feedings.Include(f => f.Reptile);
            return View(feedings.ToList());
        }

        // GET: Feedings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feeding feeding = db.Feedings.Find(id);
            if (feeding == null)
            {
                return HttpNotFound();
            }
            return View(feeding);
        }
        // inside  reptile controller
        // GET: Feedings/Create
      /*  public ActionResult Create()
        {
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName");
            return View();
        }

        // POST: Feedings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedingId,Date,Feedings,FoodSize,NumItemsFed,Notes,ReptileId")] Feeding feeding)
        {
            if (ModelState.IsValid)
            {
                db.Feedings.Add(feeding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", feeding.ReptileId);
            return View(feeding);
        }*/

        // GET: Feedings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feeding feeding = db.Feedings.Find(id);
            if (feeding == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", feeding.ReptileId);
            return View(feeding);
        }

        // POST: Feedings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedingId,Date,Feedings,FoodSize,NumItemsFed,Notes,ReptileId")] Feeding feeding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", feeding.ReptileId);
            return View(feeding);
        }

        // GET: Feedings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feeding feeding = db.Feedings.Find(id);
            if (feeding == null)
            {
                return HttpNotFound();
            }
            return View(feeding);
        }

        // POST: Feedings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feeding feeding = db.Feedings.Find(id);
            db.Feedings.Remove(feeding);
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
