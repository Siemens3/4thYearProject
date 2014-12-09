using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReptileWeb.Models;

namespace ReptileWeb.Controllers
{
    [AllowAnonymous]
    public class ReptileManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReptileManager
        public ActionResult Index()
        {
            return View(db.Reptiles.ToList());
        }

        // GET: ReptileManager/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // GET: ReptileManager/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReptileManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "Id,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous")] Reptile reptile)
        {
            if (ModelState.IsValid)
            {
                db.Reptiles.Add(reptile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reptile);
        }

        // GET: ReptileManager/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // POST: ReptileManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous")] Reptile reptile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reptile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reptile);
        }

        // GET: ReptileManager/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // POST: ReptileManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Reptile reptile = db.Reptiles.Find(id);
            db.Reptiles.Remove(reptile);
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
