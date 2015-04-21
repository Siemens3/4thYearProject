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
        public void GetHealthColourRedSnake()
        {
            HealthStatus health = new HealthStatus();
            var id = "1";
            string red = "#FF0000";
            string colourRed = health.GetHealth(id).Item1;
            Assert.AreEqual(red, colourRed);
        }
        [TestMethod()]
        public void GetHealthCheckBorn6MonthsSnake()
        {
            HealthStatus health = new HealthStatus();
            var id = "1";
            List<String> messages = health.GetHealth(id).Item2;
            Assert.AreEqual(6, messages.Count);
        }

        [TestMethod()]
        public void GetHealthColourBlackSnake()
        {
            HealthStatus health = new HealthStatus();
            var id = "2";
            string black = "#000000";
            string colourBlack = health.GetHealth(id).Item1;
            Assert.AreEqual(black, colourBlack);
        }
       
        [TestMethod()]
        public void GetHealthCheckBorn3_6MonthsSnake()
        {
            HealthStatus health = new HealthStatus();
            var id = "2";
            List<String> weightLossMessage = health.GetHealth(id).Item2;
            Assert.AreEqual(5, weightLossMessage.Count);
        }

        [TestMethod()]
        public void GetHealthColourOrangeYellowSnake()
        {
            HealthStatus health = new HealthStatus();
            var id = "5";
            string orangeYellow = "#FFCC00";
            string colourOrangeYellow = health.GetHealth(id).Item1;
            Assert.AreEqual(orangeYellow, colourOrangeYellow);
        }
        [TestMethod()]
        public void GetHealthCheckBorn3_6MonthsSnake2()
        {
            HealthStatus health = new HealthStatus();
            var id = "5";
            List<String> messages = health.GetHealth(id).Item2;
            Assert.AreEqual(2, messages.Count);
        }
       
         [TestMethod()]
        public void GetHealthColourCheckUnmellowYellow()
        {
            HealthStatus health = new HealthStatus();
            var id = "6";
            string yellow = "#FFFF66";
            string colourYellow = health.GetHealth(id).Item1;
            Assert.AreEqual(yellow, colourYellow);
       }

         [TestMethod()]
         public void GetHealthColourCheckOrange()
         {
             HealthStatus health = new HealthStatus();
             var id = "7";
             string orange = "#FF9900";
             string colourOrange = health.GetHealth(id).Item1;
             Assert.AreEqual(orange, colourOrange);
         }

         [TestMethod()]
         public void GetHealthCheckBorn1_2Months()
         {
             HealthStatus health = new HealthStatus();
             var id = "7";
             List<String> weightLossMessage = health.GetHealth(id).Item2;
             Assert.AreEqual(3, weightLossMessage.Count);
         }

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
            Assert.AreEqual(1,weightLossMessage.Count);
         }
        
         [TestMethod()]
         public void GetHealthCheckBorn3_6Months()
         {
             HealthStatus health = new HealthStatus();
             var id = "8";

             List<String> weightLossMessage = health.GetHealth(id).Item2;


             Assert.AreEqual(3, weightLossMessage.Count);
         }
         [TestMethod()]
         public void GetHealthCheckBorn6Months()
         {
             HealthStatus health = new HealthStatus();
             var id = "9";

             List<String> weightLossMessage = health.GetHealth(id).Item2;
            

             Assert.AreEqual(5, weightLossMessage.Count);
         }
         [TestMethod()]
         public void GetHealthCheckBorn6Months2()
         {
             HealthStatus health = new HealthStatus();
             var id = "10";
             List<String> messages = health.GetHealth(id).Item2;
             Assert.AreEqual(0, messages.Count);
         }
        

    }
}
