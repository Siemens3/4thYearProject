using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QRCoder;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing.Imaging;

namespace ReptileWeb.Models
{
    public enum Gender {Male, Female, Unknow}
    public enum WeightProgress { PlusWeight, MinusWeight}
    public enum FeedingType {
        [Display(Name = "African furred rats")]
        AfricanFurredRats,
        AFT,
        [Display(Name = "Brained pinky")]
        BrainedPinky,
        Bugs,Butterworms,
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
        Fruit,Gerbils,Greens,
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
        [Display(Name="Refused feed")]
        RefusedFeed,
        Regurgitation,
        Repashy,
        Superworms,
        Veggies}

    public class Reptile
    {
        public String Id { get; set; } // add so users can leave black for auto-assign
       // if a catagorie is created add a field so they can select the catagory 
    //    public QRCodeBitmapImage QR { get;  set; }
        public Gender Gender { get; set; }
        public String SpeciesName { get; set; }
        public String ScientificName { get; set; }
        public String CommonName { get; set; }
        public String Born { get; set; }
        public String Morph { get; set; }
        public Boolean Venomous { get; set; }

        public Double Weight { get; set; }
        public WeightProgress WeightProgress { get; set; }
        public String Origin { get; set; }
        public String Food { get; set; }
        public FeedingType FeedingType { get; set;}
        public Double AdultSize { get; set;}
        public String Habitat { get; set; }
      /*  
       protected void Qr(String Id)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
           Bitmap img = encoder.Encode(""); //add website link
         img.Save("C:\\Users\\Stephen\\Documents\\GitHub\\4thYearProject\\ReptileWeb\\ReptileWeb\\img\\img.jpg",ImageFormat.Jpeg);
         QR.ImageUrl = "img.jpg";
       }
         */

    }
    /*
     public class QRCoder
    {
         private void renderQRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(Id,QRCodeGenerator.ECCLevel.H);

            qrCode= ImageQR = qrCode.GetGraphic(20);
         
        }

     }
     */

}