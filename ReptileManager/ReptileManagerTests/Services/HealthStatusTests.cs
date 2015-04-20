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
        public void GetHealthColourCheckYellow()
        {
            HealthStatus health = new HealthStatus();
            var id = "6";
            string yellow = "#FFFF66";
            string colourYellow = health.GetHealth(id).Item1;
            Assert.AreEqual(yellow, colourYellow);
       }
         [TestMethod()]
         public void GetHealthColourCheckOrangeYellow()
         {
             HealthStatus health = new HealthStatus();
             var id = "7";
             string orangeYellow = "#FF9900";
             string colourOrangeYellow = health.GetHealth(id).Item1;
             Assert.AreEqual(orangeYellow, colourOrangeYellow);
         }
     /*    [TestMethod]
         public void GetHealthColourCheckOrangeYellow()
         {
             HealthStatus health = new HealthStatus();
             var id = "8";
             string yellow = "#FFCC00";
             string colourOrangeYellow = health.GetHealth(id).Item1;
             Assert.AreEqual(yellow, colourOrangeYellow);
         }*/
         [TestMethod]
         public void GetHealthColourCheckRed()
         {
             HealthStatus health = new HealthStatus();
             var id = "9";
             string red = "#FF0000";
             string colourRed = health.GetHealth(id).Item1;
             Assert.AreEqual(red, colourRed);
         }
         [TestMethod]
         public void GetHealthColourGreen()
         {
             HealthStatus health = new HealthStatus();
             var id = "10";
             string green = "#7EBF7E";
             string colourGreen= health.GetHealth(id).Item1;
             Assert.AreEqual(green, colourGreen);
         }



         [TestMethod()]
         public void GetHealthCheckBornUnder30()
         {
             HealthStatus health = new HealthStatus();
             var id = "6";
              
            List<String> weightLossMessage = health.GetHealth(id).Item2;
             System.Diagnostics.Trace.WriteLine("Testing unit test");
           System.Diagnostics.Trace.WriteLine(weightLossMessage.Count);
           
             Assert.IsNotNull(weightLossMessage);
         }
         [TestMethod()]
         public void GetHealthCheckBorn1_2Months()
         {
             HealthStatus health = new HealthStatus();
             var id = "7";

             List<String> weightLossMessage = health.GetHealth(id).Item2;
             System.Diagnostics.Trace.WriteLine("Testing unit test");
             System.Diagnostics.Trace.WriteLine(weightLossMessage.Count);

             Assert.IsNotNull(weightLossMessage);
         }
         [TestMethod()]
         public void GetHealthCheckBorn3_6Months()
         {
             HealthStatus health = new HealthStatus();
             var id = "8";

             List<String> weightLossMessage = health.GetHealth(id).Item2;
             System.Diagnostics.Trace.WriteLine("Testing unit test");
             System.Diagnostics.Trace.WriteLine(weightLossMessage.Count);

             Assert.IsNotNull(weightLossMessage);
         }
         [TestMethod()]
         public void GetHealthCheckBorn6Months()
         {
             HealthStatus health = new HealthStatus();
             var id = "9";

             List<String> weightLossMessage = health.GetHealth(id).Item2;
             System.Diagnostics.Trace.WriteLine("Testing unit test");
             System.Diagnostics.Trace.WriteLine(weightLossMessage.Count);

             Assert.IsNotNull(weightLossMessage);
         }
         [TestMethod()]
         public void GetHealthCheckBorn6Months2()
         {
             HealthStatus health = new HealthStatus();
             var id = "10";
             List<String> messages = health.GetHealth(id).Item2;
             Assert.ReferenceEquals(messages,0);
         }
        

    }
}
