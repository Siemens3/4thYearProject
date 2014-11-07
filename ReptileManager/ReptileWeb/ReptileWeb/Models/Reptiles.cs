using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReptileWeb.Models
{
    public enum Gender {Male, Female, Unknow}
    public class Reptile
    {
        public String Id { get; set; }
        public Gender Gender { get; set; }
        public String SpeciesName { get; set; }
        public String ScientificName { get; set; }
        public String CommonName { get; set; }
        public String Born { get; set; }
        public String Morph { get; set; }
        public Boolean Venomous { get; set; }

    }

}