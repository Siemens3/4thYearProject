using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ReptileManager.Services.Tests
{
    [TestClass()]
    public class HealthStatusTests
    {
        
         [TestMethod()]
        public void GetHealthColourCheckGreen()
        {
            HealthStatus health = new HealthStatus();
            var id = "6";
            string  green = "#7EBF7E";
            string colourGreen = health.GetHealth(id).Item1;
            Assert.AreEqual(green, colourGreen);
       }
         [TestMethod()]
         public void GetHealthColourCheckYellow()
         {
             HealthStatus health = new HealthStatus();
             var id = "7";
             string yellow = "#FFFF66";
             string colourYellow = health.GetHealth(id).Item1;
             Assert.AreEqual(yellow, colourYellow);
         }
         [TestMethod]
         public void GetHealthColourCheckOrangeYellow()
         {
             HealthStatus health = new HealthStatus();
             var id = "8";
             string yellow = "#FFCC00";
             string colourOrangeYellow = health.GetHealth(id).Item1;
             Assert.AreEqual(yellow, colourOrangeYellow);
         }
         [TestMethod]
         public void GetHealthColourCheckOrange()
         {
             HealthStatus health = new HealthStatus();
             var id = "9";
             string orange = "#FF9900";
             string colourOrange = health.GetHealth(id).Item1;
             Assert.AreEqual(orange, colourOrange);
         }
         [TestMethod]
         public void GetHealthColourRed()
         {
             HealthStatus health = new HealthStatus();
             var id = "10";
             string red = "#FF9900";
             string colourRed= health.GetHealth(id).Item1;
             Assert.AreEqual(red, colourRed);
         }



         [TestMethod()]
         public void GetHealthCheckBornUnder30()
         {
             HealthStatus health = new HealthStatus();
             var id = "6";
              
            List<String> weightLossMessage = health.GetHealth(id).Item2;
             System.Diagnostics.Trace.WriteLine("Testing unit test");
           System.Diagnostics.Trace.WriteLine(weightLossMessage.Count);
           
             Assert.IsNull(weightLossMessage);
         }
    }
}
