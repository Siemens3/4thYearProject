using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReptileManager.Models;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Drawing;


namespace ReptileManager.Controllers
{
    public class ReptilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reptiles
        public ActionResult Index()
        {
            return View(db.Reptiles.ToList());
        }
      
       public async Task<ActionResult> Images(string id)
       {
          
          ViewBag.Message = "Your Qr codes for this reptile";
          var QrCodeToRetrieve = await db.Reptiles.FindAsync(id);

        //  var convertedImage = QrCodeToRetrieve.byteArrayToImage(QrCodeToRetrieve.QRCode);

          byte[] imgBytes = QrCodeToRetrieve.QRCode;
          
          
            return File(imgBytes,"image/png");
          }

     
       

     

      

        // GET: Reptiles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.Include(r => r.Files).SingleOrDefaultAsync(r => r.ReptileId == id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // GET: Reptiles/Create
      //  [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reptiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
     //   [Authorize(Roles = "canEdit")]
        public async Task<ActionResult> Create([Bind(Include = "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment")] Reptile reptile,HttpPostedFileBase upload)
        {
            try
            {

            
                if (ModelState.IsValid)
                {

                    if (upload != null && upload.ContentLength > 0)
                    {
                        var image = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.image,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            
                            image.Content = reader.ReadBytes(upload.ContentLength);
                           
                        }
                       
                        reptile.Files = new List<File> { image };
                    }
                    //creates qr code and saves it as binary data
                    var newQr = reptile.QrGen();

                    var byteContent = reptile.imageToByteArray(newQr);
                    reptile.QRCode = byteContent; 

                   
                  
                    
                    db.Reptiles.Add(reptile);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException  /*dex*/ )
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                //dex.GetBaseException();
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
        
            return View(reptile);
        }

        // GET: Reptiles/Edit/5
       //  [Authorize(Roles = "canEdit")]
        public  async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await  db.Reptiles.Include(r => r.Files).SingleOrDefaultAsync(r => r.ReptileId == id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // POST: Reptiles/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(string id,[Bind(Include = "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment")] Reptile reptile,HttpPostedFileBase upload)
        {
            if(reptile.ReptileId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reptileToUpdate = await db.Reptiles.FindAsync(id);
           if(TryUpdateModel(reptileToUpdate,"", new string[] {"ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment"}))
           {
               try
               {
                   if(upload != null && upload.ContentLength > 0)
                   {
                       if (reptileToUpdate.Files.Any(f => f.FileType == FileType.image))
                       {
                           db.Files.Remove(reptileToUpdate.Files.First(f => f.FileType == FileType.image));
                       }
                       var image = new File
                       {
                           FileName = System.IO.Path.GetFileName(upload.FileName),
                           FileType = FileType.image,
                           ContentType = upload.ContentType
                       };
                       using (var reader = new System.IO.BinaryReader(upload.InputStream))
                       {
                           image.Content = reader.ReadBytes(upload.ContentLength);
                       }
                       reptileToUpdate.Files = new List<File> { image };
                   }
                    db.Entry(reptileToUpdate).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
               }
               catch (RetryLimitExceededException /* dex */)
               {
                   //Log the error (uncomment dex variable name and add a line here to write a log.
                   ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
               }
           }
            return View(reptileToUpdate);
        }

        // GET: Reptiles/Delete/5
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

        // POST: Reptiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                Reptile reptile = await db.Reptiles.FindAsync(id);
                foreach (var entry in reptile.Files.ToList())
                {
                    db.Files.Remove(entry);
                }
                db.Reptiles.Remove(reptile);
                await db.SaveChangesAsync();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        // GET: Matings/Create
        public async Task<ActionResult> Mating(string id,Mating mating)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
          
           // ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "ReptileId", mating.ReptileId);
            mating.ReptileId = reptile.ReptileId;
            return View(mating);
          
           
            
        }

        // POST: Matings/Create
      
        // fix error issue 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Mating([Bind(Include = "MatingId,Event,Date,mateID,ReptileId")] Mating mating)
        {
           /* if(mating.mateID.Equals(mating.ReptileId))
            {
                ViewBag.Message = "Reptiles have the same ID, please make sure they are different";
                
                return View(mating);
            }
            else */
            if (ModelState.IsValid)
            {
                db.Matings.Add(mating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

        // ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "ReptileId",mating.ReptileId);
            
            return View(mating);
        }
        public async Task<ActionResult> MatingDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mating mating = await db.Matings.FindAsync(id);
            if (mating == null)
            {
                return HttpNotFound();
            }
            return View(mating);
        }
        // GET: Notifications/Create
        public async Task<ActionResult> Notification(string id, Notification notifi)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            notifi.ReptileId = reptile.ReptileId;
            return View(notifi);
        }

        // POST: Notifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Notification([Bind(Include = "NotificationId,Description,Message,SendAt,ReptileId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            
            return View(notification);
        }
        
        // GET: Other/Create
        public async Task<ActionResult> Other(string id,Other other)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            other.ReptileId = reptile.ReptileId;
            return View(other);
        }

        // POST: Other/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Other([Bind(Include = "OtherId,Date,Newaction,Notes,ReptileId")] Other other)
        {
            if (ModelState.IsValid)
            {
                db.Other.Add(other);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

          
            return View(other);
        }

        // GET: Medications/Create
        // 
        public async Task<ActionResult> Medication(string id, Medication medication)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            medication.ReptileId = reptile.ReptileId;
            return View(medication);
        }

        // POST: Medications/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Medication([Bind(Include = "MedicationId,Date,MedicationField,Notes,ReptileId")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                db.Medications.Add(medication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            
            return View(medication);
        }

        // GET: Sheds/Create
        public async Task<ActionResult> Shed(string id,Shed shed)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            shed.ReptileId = reptile.ReptileId;
            return View(shed);
        }

        // POST: Sheds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Shed([Bind(Include = "ShedId,Date,Sheds,Notes,ReptileId")] Shed shed)
        {
            if (ModelState.IsValid)
            {
                db.Sheds.Add(shed);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           
            return View(shed);
        }

        // GET: Defications/Create
        // inside reptile controller
        public async Task<ActionResult> Defication(string id, Defication defica)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            defica.ReptileId = reptile.ReptileId;
            return View(defica);
          
        }

        // POST: Defications/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Defication([Bind(Include = "DeficationId,Date,Defications,Notes,ReptileId")] Defication defication)
        {
            if (ModelState.IsValid)
            {
                db.Defications.Add(defication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

          
            return View(defication);
        }

        // GET: Cleanings/Create
           public async Task<ActionResult> Cleaning(string id, Cleaning clean)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Reptile reptile = await db.Reptiles.FindAsync(id);
               if (reptile == null)
               {
                   return HttpNotFound();
               }
               clean.ReptileId = reptile.ReptileId;
               return View(clean);
           }

           // POST: Cleanings/Create
           // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
           // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<ActionResult> Cleaning([Bind(Include = "CleaningId,Date,Cleanings,Notes,ReptileId")] Cleaning cleaning)
           {
               if (ModelState.IsValid)
               {
                   db.Cleanings.Add(cleaning);
                   await db.SaveChangesAsync();
                   return RedirectToAction("Index");
               }

             
               return View(cleaning);
           }
           // GET: Feedings/Create
           public async Task<ActionResult> Feeding(string id, Feeding feed)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Reptile reptile = await db.Reptiles.FindAsync(id);
               if (reptile == null)
               {
                   return HttpNotFound();
               }
               feed.ReptileId = reptile.ReptileId;
               return View(feed);
           }

           // POST: Feedings/Create
           
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<ActionResult> Feeding([Bind(Include = "FeedingId,Date,Feedings,FoodSize,NumItemsFed,Notes,ReptileId")] Feeding feeding)
           {
               /*   add this later
               if(feeding.Feedings == null || feeding.FoodSize == null)
               {
                   ViewBag.Message = "Please select food size or food type.";
               }
                * */
               if (ModelState.IsValid)
               {
                   db.Feedings.Add(feeding);
                   await db.SaveChangesAsync();
                   return RedirectToAction("Index");
               }

              
               return View(feeding);
           }
           
        // GET: BreedingCycles/Create
       public async Task<ActionResult> BreedingCycle(string id,BreedingCycle BreedCyc)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            BreedCyc.ReptileId = reptile.ReptileId;
            return View(BreedCyc);
        }

        // POST: BreedingCycles/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BreedingCycle([Bind(Include = "BreedingCycleId,Date,BreedStage,Notes,ReptileId")] BreedingCycle breedingCycle)
        {
            if (ModelState.IsValid)
            {
                db.BreedingCycles.Add(breedingCycle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "ReptileId", breedingCycle.ReptileId);
            return View(breedingCycle);
        }

         // GET: Ultrasounds/Create
         public async Task<ActionResult> Ultrasound(string id, Ultrasound ultras)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            ultras.ReptileId = reptile.ReptileId;
            return View(ultras);
           
        }

        // POST: Ultrasounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<ActionResult> Ultrasound([Bind(Include = "UltrasoundId,Date,Ultrasounds,Count,FollicleSize,Notes,ReptileId")] Ultrasound ultrasound)
        {
            if (ModelState.IsValid)
            {
                db.Ultrasounds.Add(ultrasound);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

          
            return View(ultrasound);
        }

        // GET: Notes/Create
        public async Task<ActionResult> Note(string id,Note note)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            note.ReptileId = reptile.ReptileId;
            return View(note);
            
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Note([Bind(Include = "NoteId,Notes,CategNote,ReptileId")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

      
            return View(note);
        }

        // GET: Weights/Create
       
       public async Task<ActionResult> Weight(string id, Weight weight)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            weight.ReptileId = reptile.ReptileId;
            return View(weight);
        }

        // POST: Weights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Weight([Bind(Include = "WeightId,Weights,Date,ReptileId")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                db.Weights.Add(weight);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

         
            return View(weight);
        }
        //get
        public async Task<ActionResult> Length(string id,Length length)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            length.ReptileId = reptile.ReptileId;
            return View(length);
        }

        // POST: Lengths/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Length([Bind(Include = "LengthId,Lengths,Date,ReptileId")] Length length)
        {
            if (ModelState.IsValid)
            {
                db.Lengths.Add(length);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
         
            return View(length);
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
