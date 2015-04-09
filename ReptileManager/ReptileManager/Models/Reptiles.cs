using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;


// http://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files // image tutorial 
namespace ReptileManager.Models
{

    
    public enum Gender { Male, Female, Unknow }
    public enum WeightProgress { PlusWeight, MinusWeight }
    public enum FeedingType
    {
        [Display(Name = "African furred rats")]
        AfricanFurredRats,
        AFT,
        [Display(Name = "Brained pinky")]
        BrainedPinky,
        Bugs, Butterworms,
        [Display(Name = "Chicks frozen")]
        ChicksFrozen,
        [Display(Name = "Chicks live")]
        ChicksLive,
        [Display(Name = "Chicks prekill")]
        ChicksPreKill,
        Crickets,
        Dubias,
        Earthworms,
        [Display(Name = "Frozen Anoles")]
        FrozenAnoles,
        Fruit, Gerbils, Greens,
        [Display(Name = "Guinea pig frozen")]
        GuineaPigFrozen,
        [Display(Name = "Guinea pig live")]
        GuineaPigLive,
        [Display(Name = "Guinea pig prekill")]
        GuineaPrekill,
        Hamster,
        Hornworms,
        [Display(Name = "Live Anoles")]
        LiveAnoles,
        Mealworms,
        [Display(Name = "Meat cooked")]
        MeatCooked,
        [Display(Name = "Meat raw")]
        MeatRaw,
        [Display(Name = "Mice frozen")]
        MiceFrozen,
        [Display(Name = "Mice live")]
        MiceLive,
        [Display(Name = "Mice prekill")]
        MicePrekill,
        MPR,
        [Display(Name = "Phonenix worms")]
        Phonenixworms,
        Piglets,
        [Display(Name = "Rabbit frozen")]
        RabbitsFrozen,
        [Display(Name = "Rabbit live")]
        RabbitsLive,
        [Display(Name = "Rabbit prekill")]
        RabbitsPrekill,
        [Display(Name = "Rat frozen")]
        RatFrozen,
        [Display(Name = "Rat live")]
        RatLive,
        [Display(Name = "Rat prekill")]
        RatPrekill,
        [Display(Name = "Refused feed")]
        RefusedFeed,
        Regurgitation,
        Repashy,
        Superworms,
        Veggies
    }
    public enum CleaningType
    {
        [Display(Name = "Deep clean")]
        DeepClean,
        [Display(Name = "Fresh water")]
        FreshWater,
        [Display(Name = "Spot clean")]
        SpotClean
    }
    public enum ShedType
    {
        [Display(Name = "In shed")]
        Inshed,
        [Display(Name = "Pre shed")]
        Preshed,
        Shed,
        [Display(Name = "Shed out")]
        Shedout,
        [Display(Name = "Bad shed")]
        Badshed


    }
    public enum FoodSize
    {
        Pinkie,
        Crawler,
        Fuzzie,
        Weaned,
        Pup,
        Jumbo,
        S,
        M,
        L,
        XL

    }
    public enum BreedingStage
    {
        Follicles,
        Ovulation,
        [Display(Name = "Pre Shed")]
        PreShed,
        [Display(Name = "Sperm Plugs")]
        SpermPlugs

    }
    public enum CategoryNote
    {
        Standard,
        Medical,
        [Display(Name = "Follow up")]
        Followup
    }
    public enum Event { Introduction, Courting, Breeding, Seperated }
    

    
   
    public class Reptile
    {
        
        public String ReptileId { get; set; } 
        // add so users can leave black for auto-assign
        // if a catagorie is created add a field so they can select the catagory 
        public byte[] QRCode { get;  set; }
      
         public Gender Gender { get; set; }
        public String SpeciesName { get; set; }
        public String ScientificName { get; set; }
        public String CommonName { get; set; }

       [Column(TypeName = "datetime2")]
        public DateTime? Born { get; set; }
        public String Morph { get; set; }
        public Boolean Venomous { get; set; }

        public Double Weight { get; set; }
        public WeightProgress WeightProgress { get; set; }
        public String Origin { get; set; }
        public String Food { get; set; }
        public FeedingType FeedingType { get; set; }
        public Double AdultSize { get; set; }
        public String Habitat { get; set; } 
        public String Breeder { get; set; }

        [DataType(DataType.EmailAddress)]
        public String BreederEmail { get; set; }
        // public add radio button for wild caught or CB
        public String Cities { get; set; }
        public String ClutchID { get; set; }
        public Boolean ForSale { get; set; }
        [DataType(DataType.Currency)]
        public String Price { get; set; }
        public String NickName { get; set; }
        public String LicenseNumber { get; set; }
        public String ChipNumber { get; set; }
        public String SpeciesNumber { get; set; }
        // need to pull all male IDs        public String FatherId {get;set}
        public String FatherNotInDb { get; set; }
        // image public FartherImage {get; set;}
      //  mother ID  public  String MotherId {get;set;}
      public String MotherNotInDb { get; set; }
        // image     public MotherImage {get; set;}
        //drop down list again      public String Rack {get; set;}
       public int FeedInterval { get; set; }

       [Column(TypeName = "datetime2")]
       public DateTime TimeStamp { get; set; }
      
        public DateTime DueDate { get; set; }
       public String TubeBoxNumber { get; set; }
        public String Note { get; set; }
        public String SalesCardComment { get; set; }

        //one to many
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Mating> Matings { get; set; }

       
        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Other> Others { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<Shed> Sheds { get; set; }
        public virtual ICollection<Defication> Defications { get; set; }

        public virtual ICollection<Cleaning> Cleanings { get; set; }
      
        public virtual ICollection<Feeding> Feedings { get; set; }
        public virtual ICollection<BreedingCycle> BreedingCycles { get; set; }
        public virtual ICollection<Ultrasound> Ultrasound { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Weight> Weights { get; set; }

         public virtual ICollection<Length> Lengths { get; set; }
        public String DueForFeeding() 
        {
            string today = "Today";
            string oneDayLate = "Late";
            string twoDayLate = "VeryLate";
            string noFeed = "";
           

            DateTime StartDate = TimeStamp.AddDays(FeedInterval);
            DateTime Today = DateTime.UtcNow;
            TimeSpan Deftimes = Today-StartDate;
            double DiffDefInDays = Deftimes.Days;

            if (DiffDefInDays == 1)
            {
                return oneDayLate;
            }
            // feed is  due 
            else if (DiffDefInDays == 0)
            {
                return today;
            }
            // feed is over due by at least two day
            else if (DiffDefInDays >= 2)
            {
                return twoDayLate;
            }
            else
            {
                return noFeed;
            }
        }


        public Reptile()
        {
            TimeStamp = DateTime.UtcNow;
        }
     
       

        public Image QrGen()
          {
              QRCodeEncoder encoder = new QRCodeEncoder();
              encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
              encoder.QRCodeScale = 3;
              Bitmap img = encoder.Encode(ReptileId);
          //    ImageConverter converter = new ImageConverter();
          //    QRCode = (byte[])converter.ConvertTo(img, typeof(byte[]));
           //   Image newImg = (Image)img;
              return img;
              
          }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        
    /*   public  Image byteArrayToImage(Byte[] QR)
        {
            MemoryStream ms = new MemoryStream(QR);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
         public static Image resizeImage(Image imgToResize, Size size)
                {
                     int sourceWidth = imgToResize.Width;
                     int sourceHeight = imgToResize.Height;

                       float nPercent = 0;
                       float nPercentW = 0;
                       float nPercentH = 0;

                       nPercentW = ((float)size.Width / (float)sourceWidth);
                       nPercentH = ((float)size.Height / (float)sourceHeight);

                       if (nPercentH < nPercentW)
                          nPercent = nPercentH;
                       else
                          nPercent = nPercentW;

                       int destWidth = (int)(sourceWidth * nPercent);
                       int destHeight = (int)(sourceHeight * nPercent);

                       Bitmap b = new Bitmap(destWidth, destHeight);
                       Graphics g = Graphics.FromImage((Image)b);
                       g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                       g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                       g.Dispose();

                       return (Image)b;
                    }
         */
        

    } 
  

  public class File
  {
      public int FileId { get; set; }
      [StringLength(255)]
      public string FileName { get; set; }
      [StringLength(100)]
      public string ContentType { get; set; }
      public byte[] Content { get; set; }
      public FileType FileType { get; set; }
      public String ReptileId { get; set; }
      public virtual Reptile Reptile { get; set; }
  }
  
    public class ParentView
    {
        public  Reptile Reptiles { get; set; }
        public  Mating Matings { get; set; }
    }
      // one to many relationships
     // Do not want users setting Ids of any records apart from the reptile
     public class Mating
     {
        
         public int MatingId { get; set; } // Do not want users setting Ids of any records apart from the reptile
         public Event Event { get; set; }
         //[DataType(DataType.Date)]
         //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]      -----------------add later ---------------
         public DateTime Date { get; set; }
          [Display(Name = "Mate Id")]
         public String mateID { get; set; }
         [Display(Name = "Reptile Id")]
         public String  ReptileId { get; set; }
         
         public virtual Reptile Reptile {get;set;}

     }
    
     public class Notification
     {

         public int NotificationId { get; set; }
         public String Description { get; set; }
         public String Message { get; set; }
         [Display(Name="Send At")]

         public DateTime SendAt { get; set; }
         public String ReptileId { get; set; }

         public virtual Reptile Reptile { get; set; }
     }

    
     
     public class Other
     {
         public int OtherId { get; set; }
         public DateTime Date { get; set; }
         public String Newaction { get; set; }  // if users add a custome action allow it be available  
         public String Notes { get; set; }
         public String ReptileId { get; set; }

         public virtual Reptile Reptile { get; set; }

     }
     
      
      
      
     public class Medication
     {
         public int MedicationId { get; set; }
         public DateTime Date { get; set; }
         [Display(Name="Name")]
         public String MedicationField { get; set; } // set default so field always says medication
         public String Notes { get; set; }
         public String ReptileId { get; set; }

         public virtual Reptile Reptile { get; set; }
     }
   
     public class Shed
     {
         public int ShedId { get; set; }
         public DateTime Date { get; set; }
            [Display(Name="Shed Type")]
         public ShedType Sheds { get; set; }
         public String Notes { get; set; }
         public String ReptileId { get; set; }

         public virtual Reptile Reptile { get; set; }
     }
    
     public class Defication
     {
         public int DeficationId { get; set; }
         public DateTime Date { get; set; }
         [Display(Name="Name")]
         public String Defications { get; set; } // make this fixed in the view 
         public String Notes { get; set; }
         public String ReptileId { get; set; }

         public virtual Reptile Reptile { get; set; }
     }
    
     public class Cleaning
     {
         public int CleaningId { get; set; }
         public DateTime Date { get; set; }

         [Display(Name="Cleaning")]
         public CleaningType Cleanings { get; set; } 
         public String Notes { get; set; }
         public String ReptileId { get; set; }

         public virtual Reptile Reptile { get; set; }
     }
     
      public class Feeding
      {
          public Feeding()
          {
              Date = DateTime.UtcNow;
          }
         
          public int FeedingId { get; set; }

          [Column(TypeName = "datetime2")]
          public DateTime Date { get; set; }
          [Display(Name="Food Type")]
          public FeedingType Feedings { get; set; }
           [Display(Name = "Size")]
          public FoodSize FoodSize { get; set; }
           [Display(Name = "Amount")]
          public int NumItemsFed { get; set; }
          public String Notes { get; set; }
          public String ReptileId { get; set; }

          public virtual Reptile Reptile { get; set; }
      }
    
    
      public class BreedingCycle
      {
          public int BreedingCycleId { get; set; }
          public DateTime Date { get; set; }
          [Display(Name="Stage")]
          public BreedingStage BreedStage { get; set; }
          public String Notes { get; set; }
          public String ReptileId { get; set; }

          public virtual Reptile Reptile { get; set; }
      }
    
      public class Ultrasound
      {
          public int UltrasoundId { get;set;}
          public DateTime Date { get; set; }
          [Display(Name="Name")]
          public String Ultrasounds { get; set; } //set default so field always says medication
          public Int16 Count { get; set; }
          public Double FollicleSize { get; set; }
          public String Notes { get; set; }
          public String ReptileId { get; set; }

          public virtual Reptile Reptile { get; set; }
      }
      
    
      public class Note
      {
          public int NoteId { get; set; }
          [Display(Name="Content")]
          public String Notes { get; set; }
          [Display(Name="Category")]
          public CategoryNote CategNote { get; set; } // add function later to allow users to add custome ones
          public String ReptileId { get; set; }

          public virtual Reptile Reptile { get; set; }
      }
    
      public class Weight
      {
          public int WeightId { get; set; }
          [Display(Name="Weight")]
          public int Weights { get; set; } // display in grams
          public DateTime Date { get; set; }
          public String ReptileId { get; set; }

          public virtual Reptile Reptile { get; set; }
      }
    
      public class Length
      {
          public int LengthId{get;set;}

          [Display(Name="Length")]
          public double Lengths { get; set; } // display in cm
          public DateTime Date { get; set; }
          public String ReptileId { get; set; }

          public virtual Reptile Reptile { get; set; }
      }
     
       
    }