using System;
using System.ComponentModel.DataAnnotations;

namespace ReptileManager.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        [Display(Name = "Content")]
        public String Notes { get; set; }
        [Display(Name = "Category")]
        public CategoryNote CategNote { get; set; } // add function later to allow users to add custome ones
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
    
}