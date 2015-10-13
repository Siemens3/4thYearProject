using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;


 
namespace ReptileManager.Models
{
   
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

        public string imageURL { get; set; }
        public string imageURLOne { get; set; }
        public string imageURLTwo { get; set; }
        public string imageURLThree { get; set; }
        public string imageURLFour { get; set; }
        public string imageURLFive { get; set; }
        public string imageURLSix { get; set; }

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
          
            var daysSinceLastUpdate = (DateTime.UtcNow - TimeStamp.AddDays(FeedInterval)).Days;

            if (daysSinceLastUpdate < 0)
                return Status.Default;
    

            switch (daysSinceLastUpdate)
            {
              
                case 0:
                    return Status.Today;
                case 1:
                    return Status.OneDayLate;
                default:
                    return Status.TwoOrMoreDaysLate;
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


    public static class Status
    {
        public const string Today = "Today";
        public const string OneDayLate = "Late";
        public const string TwoOrMoreDaysLate = "VeryLate";
        public const string Default = "";
    }


       
    }