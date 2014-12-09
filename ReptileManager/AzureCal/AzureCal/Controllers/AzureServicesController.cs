using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzureCal.Models;

namespace AzureCal.Controllers
{
    public class AzureServicesController : Controller
    {
        private AzureCalContext db = new AzureCalContext();

        // GET: AzureServices
        public ActionResult Index()
        {
            return View(db.AzureServiceModels.ToList());
        }

        // GET: AzureServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzureServiceModel azureServiceModel = db.AzureServiceModels.Find(id);
            if (azureServiceModel == null)
            {
                return HttpNotFound();
            }
            return View(azureServiceModel);
        }

        // GET: AzureServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AzureServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AzureServiceModel azureServiceModel)
        {
           
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm",azureServiceModel);
            }
            else
            {
                return View(azureServiceModel);
            }
            
        }
        public ActionResult Confirm(AzureServiceModel azm)
        {
            return View(azm);
        }


        // GET: AzureServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzureServiceModel azureServiceModel = db.AzureServiceModels.Find(id);
            if (azureServiceModel == null)
            {
                return HttpNotFound();
            }
            return View(azureServiceModel);
        }

        // POST: AzureServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumberInstances,InstanceSize")] AzureServiceModel azureServiceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(azureServiceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(azureServiceModel);
        }

        // GET: AzureServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzureServiceModel azureServiceModel = db.AzureServiceModels.Find(id);
            if (azureServiceModel == null)
            {
                return HttpNotFound();
            }
            return View(azureServiceModel);
        }

        // POST: AzureServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AzureServiceModel azureServiceModel = db.AzureServiceModels.Find(id);
            db.AzureServiceModels.Remove(azureServiceModel);
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
