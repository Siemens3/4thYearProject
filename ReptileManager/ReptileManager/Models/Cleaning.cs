using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReptileManager.Models
{
    public class Cleaning
    {
        public int CleaningId { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Cleaning")]
        public CleaningType Cleanings { get; set; }
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}