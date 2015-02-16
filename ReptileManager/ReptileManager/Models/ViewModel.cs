using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReptileManager.Models
{
    public class ViewModel
    {
           public IEnumerable<Reptile> Reptiles { get; set; }
           public IEnumerable<Mating> Matings { get; set; }


        
    }

}