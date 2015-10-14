using Logging;
using Persistence;
using ReptileManager.Models;
using ReptileManager.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;





namespace ReptileManager.Controllers
{
    public class ReptilesController : Controller
    {
        private ReptileContext db = new ReptileContext();
        private PhotoService photoService = new PhotoService(new Logger());

        // GET: Reptiles
        public async Task<ActionResult> Index()
        {
            return View(await db.Reptiles.ToListAsync());
        }




        public async Task<ActionResult> ProfileImage(int id)
        {
            using (var db = new ReptileContext())
            {
                var unsetProfileImage = await db.Images.Where(i => i.ProfileImage == true).FirstOrDefaultAsync();
                unsetProfileImage.ProfileImage = false;

                var imageRecord = await db.Images.Where(i => i.ImageId == id).FirstOrDefaultAsync();
                imageRecord.ProfileImage = true;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "Change main image fuck up ");
                }
                return RedirectToAction("Details", new { id = imageRecord.ReptileId });
            }
        }

        public async Task<ActionResult> DeleteImage(int id)
        {
            using (var db = new ReptileContext())
            {
                var imageRecord = await db.Images.Where(i => i.ImageId == id).FirstOrDefaultAsync();
                var reptileId = imageRecord.ReptileId;
                if (imageRecord.ProfileImage == true)
                {
                    var setNewMainImage = await db.Images.Where(i => i.ReptileId == imageRecord.ReptileId).FirstOrDefaultAsync();
                    setNewMainImage.ProfileImage = true;
                }

                try
                {
                    db.Images.Remove(imageRecord);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "Change main image fuck up ");
                }

                return RedirectToAction("Details", new { id = reptileId });
            }
        }

        public ActionResult Chart(String id)
        {
            ReptileCharts reptileChart = new ReptileCharts();
            return PartialView(reptileChart.chart(id));
        }

        public String HealthStatusIndex(string id)
        {

            var healthColour = new HealthStatus();
            return healthColour.GetHealth(id).Item1;
        }

        // cannot be async :( 
        public ActionResult HealthStatus(string id)
        {
            var healthReport = new HealthStatus();
            return PartialView(healthReport.GetHealth(id).Item2);
        }

        public async Task<ActionResult> Images(string id)
        {

            ViewBag.Message = "Your Qr codes for this reptile";
            var QrCodeToRetrieve = await db.Reptiles.FindAsync(id);

            //  var convertedImage = QrCodeToRetrieve.byteArrayToImage(QrCodeToRetrieve.QRCode);

            byte[] imgBytes = QrCodeToRetrieve.QRCode;


            return File(imgBytes, "image/png");
        }




        /*
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
         * */



        // GET: Reptiles/Details/5
        public async Task<ActionResult> Details(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //code for reptile details,image and mating table
            Reptile reptile = await db.Reptiles.Include(r => r.Files).Include(r => r.Matings).FirstOrDefaultAsync(r => r.ReptileId == id);

            //code for d3
            var reptiles = db.Reptiles.Select(r => new { Weight = r.Weights });

            //   var mating = db.Reptiles.Select(r => new { Matings = r.Matings });
            object[] weightArray = new object[2];
            foreach (var data in reptiles)
            {
                var weightData = data.Weight;
                foreach (var values in weightData)
                {
                    weightArray[0] = values.Weights;
                    weightArray[1] = values.Date;
                }
            }

            //  string json = JsonConvert.SerializeObject(weightArray);
            ViewBag.Json = weightArray;
            // var d3query = await db.Matings.ToListAsync();
            // string json = JsonConvert.SerializeObject(d3query);

            // Reptile rep = await db.Reptiles.FindAsync(id);

            // Reptile mating = await db.Reptiles.Include(r => r.Matings).SingleOrDefaultAsync(r => r.ReptileId == id);

            //var join = from reptile in db.Reptiles join m in db.Matings on reptile.ReptileId equals m.ReptileId into g where reptile.ReptileId.Equals(id)select new{Mating = g.SelectMany(d =>d.Date,d =>d.Event))}

            /* Mating mating = db.Reptiles.SelectMany(r => r.Matings)
                          .Select(o => new
                          {
                              ReptileId = o.Reptile.ReptileId,
                              Date = o.date,
                              Event = o.Event
                          });
             */
            //   ParentView parentView = new ParentView();


            //   parentView.Reptiles = reptile;
            //parentView.Matings = ;

            // Mating mating = await db.Matings.Include(r => r.).Where(r => r.ReptileId == id);
            // return all mating details assocaited with this ID and pass them to the view

            // var matingList = db.Matings.Where(m => m.mateID.Contains(id)).Select(d => new { d.Date, d.Event }).ToListAsync();

            //  ViewData["mating"] = matingList;

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
        public async Task<ActionResult> Create([Bind(Include = "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,TimeStamp,DueDate,TubeBoxNumber,Note,SalesCardComment")] Reptile reptile, IEnumerable<HttpPostedFileBase> imageList)
        {
            try
            {


                if (ModelState.IsValid)
                {

                    //if (upload != null && upload.ContentLength > 0)
                    //{
                    //    var image = new File
                    //    {
                    //        FileName = System.IO.Path.GetFileName(upload.FileName),
                    //        FileType = FileType.image,
                    //        ContentType = upload.ContentType
                    //    };
                    //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    //    {

                    //        image.Content = reader.ReadBytes(upload.ContentLength);

                    //    }

                    //    reptile.Files = new List<File> { image };
                    //}
                    // new image storage in blob
                    // reptile.images = new List<string>();
                  
                    //
                    //{

                    //    if(image.ContentLength > 0 )
                    //    {
                    //        reptile.images[i] = await photoService.UploadPhotoAsync(image);
                    //        i++;
                    //    }

                    //}
                    // This is done to ensure the first image is primary then they can change this in details later 
                    int i = 0;
                    foreach (var image in imageList)
                    {
                        Images im = new Images();
                        if (i == 0)
                        {

                            im.ImageURL = await photoService.UploadPhotoAsync(image);
                            im.ReptileId = reptile.ReptileId;
                            im.ProfileImage = true;
                            reptile.Images.Add(im);
                        }
                        else
                        {


                            im.ImageURL = await photoService.UploadPhotoAsync(image);
                            im.ReptileId = reptile.ReptileId;
                            im.ProfileImage = false;
                            reptile.Images.Add(im);
                        }
                        i++;

                    }


                    //creates qr code and saves it as binary data
                    var newQr = reptile.QrGen();

                    var byteContent = reptile.imageToByteArray(newQr);
                    reptile.QRCode = byteContent;


                    reptile.TimeStamp = DateTime.Today.ToLocalTime();

                    db.Reptiles.Add(reptile);
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }


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
        public async Task<ActionResult> Edit(string id)
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

        // POST: Reptiles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind(Include = "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment")] Reptile reptile,IEnumerable<HttpPostedFileBase> imageList)
        {
            if (reptile.ReptileId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reptileToUpdate = await db.Reptiles.FindAsync(id);
            if (TryUpdateModel(reptileToUpdate, "", new string[] { "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment" }))
            {
                try
                {
                    //if(upload != null && upload.ContentLength > 0)
                    //{
                    //    if (reptileToUpdate.Files.Any(f => f.FileType == FileType.image))
                    //    {
                    //        db.Files.Remove(reptileToUpdate.Files.First(f => f.FileType == FileType.image));
                    //    }
                    //    var image = new File
                    //    {
                    //        FileName = System.IO.Path.GetFileName(upload.FileName),
                    //        FileType = FileType.image,
                    //        ContentType = upload.ContentType
                    //    };
                    //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    //    {
                    //        image.Content = reader.ReadBytes(upload.ContentLength);
                    //    }
                    //    reptileToUpdate.Files = new List<File> { image };
                    //}
                    int i = 0;
                    var imagesCheckForMain = db.Images.Where(i => i.ReptileId == reptileToUpdate.ReptileId && i.ProfileImage == true).Any();
                    if(imagesCheckForMain)
                    {
                        i = 1;
                    }
                   
                    foreach (var image in imageList)
                    {
                        Images im = new Images();
                        if (i == 0)
                        {

                            im.ImageURL = await photoService.UploadPhotoAsync(image);
                            im.ReptileId = reptile.ReptileId;
                            im.ProfileImage = true;
                            reptile.Images.Add(im);
                        }
                        else
                        {


                            im.ImageURL = await photoService.UploadPhotoAsync(image);
                            im.ReptileId = reptile.ReptileId;
                            im.ProfileImage = false;
                            reptile.Images.Add(im);
                        }
                        i++;

                    }

                    db.Entry(reptileToUpdate).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact support.");
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
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                Reptile reptile = await db.Reptiles.FindAsync(id);

                foreach (var image in reptile.Images.ToList())
                {
                    db.Images.Remove(image);
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
        public async Task<ActionResult> Mating(string id, Mating mating)
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
        public async Task<ActionResult> Other(string id, Other other)
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
        public async Task<ActionResult> Shed(string id, Shed shed)
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
            feed.Date = DateTime.UtcNow;
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
                Reptile updateTimeStamp = await db.Reptiles.FirstOrDefaultAsync(r => r.ReptileId == feeding.ReptileId);
                updateTimeStamp.TimeStamp = feeding.Date.ToLocalTime();
                db.Reptiles.Attach(updateTimeStamp);
                db.Entry(updateTimeStamp).Property(r => r.TimeStamp).IsModified = true;

                db.Feedings.Add(feeding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(feeding);
        }

        // GET: BreedingCycles/Create
        public async Task<ActionResult> BreedingCycle(string id, BreedingCycle BreedCyc)
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
        public async Task<ActionResult> Note(string id, Note note)
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
        public async Task<ActionResult> Length(string id, Length length)
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
