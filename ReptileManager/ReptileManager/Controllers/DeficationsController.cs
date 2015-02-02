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
    public class DeficationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Defications
        public ActionResult Index()
        {
            var defications = db.Defications.Include(d => d.Reptile);
            return View(defications.ToList());
        }

        // GET: Defications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defication defication = db.Defications.Find(id);
            if (defication == null)
            {
                return HttpNotFound();
            }
            return View(defication);
        }

        // GET: Defications/Create
        // inside reptile controller
     /*   public ActionResult Create()
        {
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName");
            return View();
        }

        // POST: Defications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeficationId,Date,Defications,Notes,ReptileId")] Defication defication)
        {
            if (ModelState.IsValid)
            {
                db.Defications.Add(defication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", defication.ReptileId);
            return View(defication);
        }*/

        // GET: Defications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defication defication = db.Defications.Find(id);
            if (defication == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", defication.ReptileId);
            return View(defication);
        }

        // POST: Defications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeficationId,Date,Defications,Notes,ReptileId")] Defication defication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "SpeciesName", defication.ReptileId);
            return View(defication);
        }

        // GET: Defications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defication defication = db.Defications.Find(id);
            if (defication == null)
            {
                return HttpNotFound();
            }
            return View(defication);
        }

        // POST: Defications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Defication defication = db.Defications.Find(id);
            db.Defications.Remove(defication);
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
