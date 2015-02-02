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
    public class BreedingCyclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BreedingCycles
        public ActionResult Index()
        {
            var breedingCycles = db.BreedingCycles.Include(b => b.Reptile);
            return View(breedingCycles.ToList());
        }

        // GET: BreedingCycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreedingCycle breedingCycle = db.BreedingCycles.Find(id);
            if (breedingCycle == null)
            {
                return HttpNotFound();
            }
            return View(breedingCycle);
        }
        // inside reptileController
        // GET: BreedingCycles/Create
     /*   public ActionResult Create()
        {
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName");
            return View();
        }

        // POST: BreedingCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreedingCycleId,Date,BreedStage,Notes,ReptileId")] BreedingCycle breedingCycle)
        {
            if (ModelState.IsValid)
            {
                db.BreedingCycles.Add(breedingCycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", breedingCycle.ReptileId);
            return View(breedingCycle);
        }
        */
        // GET: BreedingCycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreedingCycle breedingCycle = db.BreedingCycles.Find(id);
            if (breedingCycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", breedingCycle.ReptileId);
            return View(breedingCycle);
        }

        // POST: BreedingCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BreedingCycleId,Date,BreedStage,Notes,ReptileId")] BreedingCycle breedingCycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breedingCycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", breedingCycle.ReptileId);
            return View(breedingCycle);
        }

        // GET: BreedingCycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreedingCycle breedingCycle = db.BreedingCycles.Find(id);
            if (breedingCycle == null)
            {
                return HttpNotFound();
            }
            return View(breedingCycle);
        }

        // POST: BreedingCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BreedingCycle breedingCycle = db.BreedingCycles.Find(id);
            db.BreedingCycles.Remove(breedingCycle);
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
