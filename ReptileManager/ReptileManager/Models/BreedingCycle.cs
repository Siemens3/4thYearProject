using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class BreedingCycle
    {
        public int BreedingCycleId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Stage")]
        public BreedingStage BreedStage { get; set; }
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
    
}