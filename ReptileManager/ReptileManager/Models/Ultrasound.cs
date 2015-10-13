using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Ultrasound
    {
        public int UltrasoundId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Name")]
        public String Ultrasounds { get; set; } //set default so field always says medication
        public Int16 Count { get; set; }
        public Double FollicleSize { get; set; }
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}