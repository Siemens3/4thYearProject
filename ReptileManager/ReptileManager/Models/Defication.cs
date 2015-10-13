using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Defication
    {
        public int DeficationId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Name")]
        public String Defications { get; set; } // make this fixed in the view 
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}