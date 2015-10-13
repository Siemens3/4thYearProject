using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReptileManager.Models
{
    public class Other
    {
        public int OtherId { get; set; }
        public DateTime Date { get; set; }
        public String Newaction { get; set; }  // if users add a custome action allow it be available  
        public String Notes { get; set; }
        public String ReptileId { get; set; }

        public virtual Reptile Reptile { get; set; }

    }
}