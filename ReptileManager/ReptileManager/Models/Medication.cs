using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Medication
    {
        public int MedicationId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Name")]
        public String MedicationField { get; set; } // set default so field always says medication
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}