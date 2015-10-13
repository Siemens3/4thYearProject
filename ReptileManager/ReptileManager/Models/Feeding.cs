using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReptileManager.Models
{
    public class Feeding
    {
        public Feeding()
        {
            Date = DateTime.UtcNow;
        }

        public int FeedingId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [Display(Name = "Food Type")]
        public FeedingType Feedings { get; set; }
        [Display(Name = "Size")]
        public FoodSize FoodSize { get; set; }
        [Display(Name = "Amount")]
        public int NumItemsFed { get; set; }
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }
    }
}