using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReptileManager.Models
{

    // one to many relationships
    // Do not want users setting Ids of any records apart from the reptile
    public class Mating
    {

        public int MatingId { get; set; } // Do not want users setting Ids of any records apart from the reptile
        public Event Event { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]      -----------------add later ---------------
        public DateTime Date { get; set; }
        [Display(Name = "Mate Id")]
        public String mateID { get; set; }
        [Display(Name = "Reptile Id")]
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }

    }
}