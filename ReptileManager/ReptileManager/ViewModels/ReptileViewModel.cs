using ReptileManager.CustomDataAnnotation; 
using ReptileManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;



namespace ReptileManager.ViewModels
{
    public class ReptileViewModel
    {


        public string ReptileId { get; set; }
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
        public String Morph { get; set; }
        public Boolean Venomous { get; set; }
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
        // need to pull all male IDs        public String FatherId {get;set}
        public string FatherNotInDb { get; set; }
        
        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase FartherImage { get; set; }
        //  mother ID  
        public string MotherId { get; set; }
        public string MotherNotInDb { get; set; }
        
        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase MotherImage { get; set; }
        //drop down list again      public String Rack {get; set;}
        public int FeedInterval { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public DateTime DueDate { get; set; }
        public string TubeBoxNumber { get; set; }
        public string Note { get; set; }
        public string SalesCardComment { get; set; }

        public string fartherId { get; set; }
        public string mortherId { get; set; }
        public List<SelectListItem> ListOfMales { get; set; }
        public List<SelectListItem> ListOfFemales { get; set; }
    }
}