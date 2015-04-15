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
    
    public class MatingsController : Controller
    {
        private ReptileContext db = new ReptileContext();

        // GET: Matings
        public ActionResult Index()
        {
            var matings = db.Matings.Include(m => m.Reptile);
            return View(matings.ToList());
        }

        // GET: Matings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mating mating = db.Matings.Find(id);
            if (mating == null)
            {
                return HttpNotFound();
            }
            return View(mating);
        }

        // GET: Matings/Create
        // added to reptile controller
     /*   public ActionResult Create()
        {
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName");
            return View();
        } 
*/
        // POST: Matings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // added to reptile controller
   /*     [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatingId,Event,Date,mateID,ReptileId")] Mating mating)
        {
            if (ModelState.IsValid)
            {
                db.Matings.Add(mating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", mating.ReptileId);
            return View(mating);
        }
*/
        // GET: Matings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mating mating = db.Matings.Find(id);
            if (mating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", mating.ReptileId);
            return View(mating);
        }

        // POST: Matings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatingId,Event,Date,mateID,ReptileId")] Mating mating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", mating.ReptileId);
            return View(mating);
        }

        // GET: Matings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mating mating = db.Matings.Find(id);
            if (mating == null)
            {
                return HttpNotFound();
            }
            return View(mating);
        }

        // POST: Matings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mating mating = db.Matings.Find(id);
            db.Matings.Remove(mating);
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
