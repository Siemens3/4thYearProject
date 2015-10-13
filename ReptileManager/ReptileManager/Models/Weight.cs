using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Weight
    {
        public int WeightId { get; set; }
        [Display(Name = "Weight")]
        public int Weights { get; set; } // display in grams
        public DateTime Date { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}