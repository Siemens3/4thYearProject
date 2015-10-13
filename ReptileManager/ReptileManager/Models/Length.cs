using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Length
    {
        public int LengthId { get; set; }

        [Display(Name = "Length")]
        public double Lengths { get; set; } // display in cm
        public DateTime Date { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}