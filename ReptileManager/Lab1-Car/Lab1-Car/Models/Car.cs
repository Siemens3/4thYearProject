using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab1_Car.Models
{
    public enum EngineType {Petrol,Diesel,Hybrid }
    public class Car
    {
        public int Id { get; set; }
        public String Make {get;set;}
        public String Model {get;set;}
        public Double EngineSize {get;set;}
        public EngineType EngineType { get; set; }
      
    }
}