using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Shed
    {
        public int ShedId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Shed Type")]
        public ShedType Sheds { get; set; }
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}