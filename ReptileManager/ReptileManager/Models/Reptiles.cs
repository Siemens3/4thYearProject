using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;



namespace ReptileManager.Models
{

    public class Reptile
    {

        public Reptile()
        {
            TimeStamp = DateTime.UtcNow;
            Images = new List<Images>();
        }


        public String ReptileId { get; set; }
        // add so users can leave black for auto-assign
        // if a catagorie is created add a field so they can select the catagory 
        public byte[] QRCode { get; set; }

        public Gender Gender { get; set; }
        public String SpeciesName { get; set; }
        [Required]
        public String ScientificName { get; set; }
        public String CommonName { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime? Born { get; set; }
        public string Morph { get; set; }
        public bool Venomous { get; set; }
        [Required]
        public double Weight { get; set; }
        public WeightProgress WeightProgress { get; set; }
        public string Origin { get; set; }
        public string Food { get; set; }
        public FeedingType FeedingType { get; set; }
        public double AdultSize { get; set; }
        public string Habitat { get; set; }
        public string Breeder { get; set; }

        [DataType(DataType.EmailAddress)]
        public string BreederEmail { get; set; }
        // public add radio button for wild caught or CB
        public string Cities { get; set; }
        public string ClutchID { get; set; }
        public bool ForSale { get; set; }
        [DataType(DataType.Currency)]
        public string Price { get; set; }
        public string NickName { get; set; }
        public string LicenseNumber { get; set; }
        public string ChipNumber { get; set; }
        public string SpeciesNumber { get; set; }
        // need to pull all male IDs        
        public string FatherId { get; set; }
        public string FatherNotInDb { get; set; }
        public string FartherImage {get; set;}
        //  mother ID  public  String MotherId {get;set;}
        public string MotherNotInDb { get; set; }
        public string MotherImage {get; set;}
        //drop down list again      public String Rack {get; set;}
        public int FeedInterval { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public DateTime DueDate { get; set; }
        public string TubeBoxNumber { get; set; }
        public string Note { get; set; }
        public string SalesCardComment { get; set; }


        //one to many
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Mating> Matings { get; set; }

        public virtual ICollection<Images> Images { get; set; }




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


    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageURL { get; set; }
        public string ReptileId { get; set; }
        public virtual Reptile Reptile { get; set; }
        public bool ProfileImage { get; set; }
    }

    public static class Status
    {
        public const string Today = "Today";
        public const string OneDayLate = "Late";
        public const string TwoOrMoreDaysLate = "VeryLate";
        public const string Default = "";
    }



}