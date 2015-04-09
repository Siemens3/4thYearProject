using ReptileManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using System.Drawing;





namespace ReptileManager.Controllers
{
    public class ReptilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reptiles
        public  ActionResult Index()
        {
            return  View(db.Reptiles.ToList());
        }
       
        public ActionResult Chart(String id)
        {
            var reptileType = db.Reptiles.FirstOrDefault(r => r.ReptileId == id);
            var weights = (from w in db.Weights where w.ReptileId == id select w.Weights);
            var feedings = (from f in db.Feedings where f.ReptileId == id select f.NumItemsFed);
            var lengths = (from l in db.Lengths where l.ReptileId == id select l.Lengths);

           Object[] AvgForSpecies =  new Object[12];
          
           if( reptileType.ScientificName.Equals("Python regius"))
           {
              
               Object[] PythonArray = new Object[12];
               PythonArray[0] = 61.73;
               PythonArray[1] = 82.20;
               PythonArray[2] = 146.47;
               PythonArray[3] = 230.33;
               PythonArray[4] = 288.20;
               PythonArray[5] = 346.40;
               PythonArray[6] = 377.87;
               PythonArray[7] = 406.20;
               PythonArray[8] = 445.20;
               PythonArray[9] = 476.73;
               PythonArray[10] = 506.27;
               PythonArray[11] = 546;

               AvgForSpecies = PythonArray;

           }
           else if (reptileType.ScientificName.Equals("Eublepharis macularius"))
           {
             
               Object[] LeopardArray = new Object[12];
               LeopardArray[0] = 2;
               LeopardArray[1] = 4;
               LeopardArray[2] = 5.5;
               LeopardArray[3] = 7.23;
               LeopardArray[4] = 9;
               LeopardArray[5] = 12.43;
               LeopardArray[6] = 15.98;
               LeopardArray[7] = 17;
               LeopardArray[8] = 18.96;
               LeopardArray[9] = 24;
               LeopardArray[10] = 30;
               LeopardArray[11] = 37;

               AvgForSpecies = LeopardArray;

           }
            List<int> WeightAmount = new List<int>();
            List<int> FeedingsAmount = new List<int>();
            List<Double> LengthsAmount = new List<Double>();

            foreach (var w in weights)
            {
                WeightAmount.Add(w);
            }
            foreach (var f in feedings)
            {
                FeedingsAmount.Add(f);
            }
            foreach (var l in lengths)
            {
                LengthsAmount.Add(l);
            }

            WeightAmount.ToArray();
            object[] newWeightsObj;
            newWeightsObj = WeightAmount.Cast<object>().ToArray();

            FeedingsAmount.ToArray();
            object[] newFeedingsObj;
            newFeedingsObj = FeedingsAmount.Cast<object>().ToArray();

            LengthsAmount.ToArray();
            object[] newLengthsObj;
            newLengthsObj = LengthsAmount.Cast<object>().ToArray();

            Highcharts g2 = new Highcharts("chart2")
               .InitChart(new Chart { Type = ChartTypes.Column })
               .SetTitle(new Title { Text = "Feedings" })
               .SetXAxis(new XAxis { Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Title = new YAxisTitle { Text = "grams" }
               })
               .SetLegend(new Legend
               {
                   Layout = Layouts.Vertical,
                   Align = HorizontalAligns.Center,
                   VerticalAlign = VerticalAligns.Bottom,
                   X = 125,
                   Y = 70,
                   Floating = true,
                   BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                   Shadow = true
               })
               .SetTooltip(new Tooltip { Formatter = @"function() { return ''+ this.x +': '+ this.y +' grams'; }" })
               .SetPlotOptions(new PlotOptions
               {
                   Column = new PlotOptionsColumn
                   {
                       PointPadding = 0.2,
                       BorderWidth = 0
                   }
               })
               .SetSeries(new[]
                {
                    new Series { Name = "Feedings", Data = new Data(newFeedingsObj) },
                    new Series { Name = "Weight", Data = new Data(newWeightsObj)},
                    new Series {Name = "Average", Data = new Data(AvgForSpecies)}
                });
          
            Highcharts g1 = new Highcharts("chart1")
                 .InitChart(new Chart { Type = ChartTypes.Areaspline })
                 .SetTitle(new Title { Text = "Weights for each month " })
                 .SetLegend(new Legend
                 {
                     Layout = Layouts.Vertical,
                     Align = HorizontalAligns.Center,
                     VerticalAlign = VerticalAligns.Bottom,
                     Floating = true,
                     BorderWidth = 1,
                     BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF"))
                 })

               .SetXAxis(new XAxis
               {
                   Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                   Title = new XAxisTitle { Text = "Months" }
               })
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Weight units" } })
                .SetSeries(new[]
                {
                    new Series {  Name = "Weights", Data = new Data(newWeightsObj)},
                    new Series {   Name = "Average", Data = new Data(AvgForSpecies)},
                   
               });

            Highcharts g3 = new Highcharts("chart3")
               .InitChart(new Chart { Type = ChartTypes.Areaspline })
               .SetTitle(new Title { Text = "Length for each month " })
               .SetLegend(new Legend
               {
                   Layout = Layouts.Vertical,
                   Align = HorizontalAligns.Left,
                   VerticalAlign = VerticalAligns.Top,
                   Floating = true,
                   BorderWidth = 1,
                   BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF"))
               })

             .SetXAxis(new XAxis
             {
                 Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                 Title = new XAxisTitle { Text = "Months" }
             })
              .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Length units in inches" } })
              .SetSeries(new Series
              {
                  Name = "Lengths",
                  Data = new Data(newLengthsObj)

              });
           
            Charts model = new Charts();
            model.Chart1 = g1;
            model.Chart2 = g2;
            model.Chart3 = g3;
           return PartialView(model);

        }
            
        public String HealthStatusIndex(String id)
        {
            int HealthStatus = 0;
            var ReptileType = db.Reptiles.FirstOrDefault(x => x.ReptileId == id);

            var latestWeight = db.Weights.OrderByDescending(w => w.Date).Where(r => r.ReptileId == id);
            

            var latestFeeding = db.Feedings.FirstOrDefault(f => f.ReptileId == id);
            var latestLength = db.Lengths.FirstOrDefault(l => l.ReptileId == id);
            var latestDefication = db.Defications.FirstOrDefault(d => d.ReptileId == id);
            var latestShed = db.Sheds.FirstOrDefault(s => s.ReptileId == id);


            List<Weight> WeightList = new List<Weight>();

            foreach (var w in latestWeight)
            {
                WeightList.Add(w);
            }




            //danger weight list to be implemented
            int DangerWeightLoss = 15;
            int MinorWeightLoss = 5;
            bool DangerWeight = false;
            bool MinorWeight = false;
            var WeightLoss = 0;


            // used for links to open in new window
            String newLink = "target=";
            String target = newLink + "_blank";

            Uri UriLeoHelp_001 = new Uri("http://www.geckosetc.com/htm/health.htm");

            // baby help
            Uri UriBabyLeoHelp_001 = new Uri("http://www.thegeckospot.net/leohatchlingcare.php");
            Uri UriBabyLeoHelp_002 = new Uri("http://www.wbeph.com/reptiles/keeping-leopard-geckoes-in-phoenix-arizona/");

            // Juvenile help
            Uri UriJuvenileLeoHelp_001 = new Uri("http://www.reptilesmagazine.com/Care-Sheets/Lizards/Leopard-Gecko/");
            Uri UriJuvenileLeoHelp_002 = new Uri("http://www.theurbangecko.com/caring-leopard-gecko");

            //breeding help
            Uri UriLeoBreedingHelp_001 = new Uri("http://www.vmsherp.com/LCBreedingLeopards.htm");
            Uri UriLeoBreedingHelp_002 = new Uri("http://www.thegeckospot.net/leobreeding.php");

            //shedding help
            Uri UriLeoSheddingHelp_001 = new Uri("http://www.leopardgeckos.co.za/health-leopard-gecko-shedding-problems.htm");
            Uri UriLeoSheddingHelp_002 = new Uri("http://www.universityvet.com/resource/eye-and-skin-problems-leopard-geckos");
            Uri UriLeoSheddingHelp_003 = new Uri("http://geckocare.net/leopard-gecko-shedding/");
            Uri UriLeoSheddingHelp_004 = new Uri("http://www.leopardgeckomorphcalculator.co.uk/Help/LeopardGeckoShedding.aspx");

            // defication help
            Uri UriLeoDeficationHelp_001 = new Uri("http://leopardgeckogal.hubpages.com/hub/What-to-do-if-your-leopard-gecko-wont-poop");
            Uri UriLeoDeficationHelp_002 = new Uri("http://www.repticzone.com/forums/Geckos-Leopard/messages/177497.html");
            Uri UriLeoDeficationHelp_003 = new Uri("https://www.youtube.com/watch?v=wvpcPS8k09c");




            //weight check
            var LastFiveWeights = WeightList.OrderByDescending(x => x.Date).Take(5);

            for (int i = 0; i < LastFiveWeights.Count(); i++)
            {
                if (ReptileType.Born.Value.AddDays(30) <= DateTime.Today)
                {
                    break;
                }
                else
                {
                    // 1-2 months
                    if (ReptileType.Born.Value.AddMonths(1) > DateTime.Today & ReptileType.Born.Value.AddMonths(2) < DateTime.Today.AddDays(30))
                    {
                        if (LastFiveWeights.FirstOrDefault().Weights < 2)
                        {
                            HealthStatus += 2;
                            ViewBag.WeightLossMessage = ReptileType.CommonName + " has not gained much weight, please follow these links on caring for young " + ReptileType.SpeciesName + ". " + "<br />" + UriBabyLeoHelp_001 + "<br />" + UriBabyLeoHelp_002;
                            break;
                        }
                    }
                    // 3-6 months
                    else if (ReptileType.Born.Value.AddMonths(3) > DateTime.Today & ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
                    {
                        if (WeightList.FirstOrDefault().Weights < 5)
                        {
                            HealthStatus += 2;
                            ViewBag.WeightLossMessage = ReptileType.NickName + " has not gained much weight, this is serious because of the age " + ReptileType.Born + " please follow these links on caring for young " + ReptileType.SpeciesName + ". " + "<br />" + UriJuvenileLeoHelp_001 + "<br />" + UriJuvenileLeoHelp_002;
                            break;
                        }
                    }
                    // greater than 6 months
                    else if (ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
                    {
                        if (LastFiveWeights.ElementAt(i).Weights > LastFiveWeights.First().Weights)
                        {
                            WeightLoss = LastFiveWeights.Last().Weights - LastFiveWeights.First().Weights;

                            System.Diagnostics.Debug.WriteLine(LastFiveWeights.Last()); // test to check order of list

                            if (WeightLoss >= DangerWeightLoss)
                            {
                                DangerWeight = true;
                                HealthStatus += 2;
                                ViewBag.WeightLossMessage = "ID:" + id + " has lost " + WeightLoss + ". This is very seriours. Helpful links:" + UriLeoHelp_001.ToString();

                            }
                            else if (WeightLoss < MinorWeightLoss)
                            {
                                MinorWeight = true;
                                HealthStatus += 1;
                                ViewBag.WeightLossMessage = "ID:" + id + " has lost " + WeightLoss + ". This reptile requires attention. Helpful links:" + UriLeoHelp_001.ToString();
                            }
                        }
                    }
                }
            }
            //breeding check
            if (HealthStatus > 0)
            {
                if (ReptileType.Gender == Gender.Female)
                {
                    DateTime start = ReptileType.DueDate;
                    DateTime newDate = DateTime.Today;
                    TimeSpan ts = newDate - start;
                    int differenceInDays = ts.Days;

                    if (differenceInDays < 14)
                    {
                        if (DangerWeight == true)
                        {
                            HealthStatus += 2;
                            ViewBag.JustGaveBirth = "This reptile just gave birth in the last two week. This would explain the weight loss of " + WeightLoss + ". This is a serious amount of weight loss. Please reconsider breeding this reptile. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                        else if (MinorWeight == true)
                        {
                            HealthStatus += 1;
                            ViewBag.JustGaveBirth = "This reptile just gave birth in the last two week. This would explain the weight loss of " + WeightLoss + ". This is a minor amount of weight loss. This would be normal. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                    }
                    else if (differenceInDays > 14 & differenceInDays < 28)
                    {
                        if (DangerWeight == true)
                        {
                            HealthStatus += 2;
                            ViewBag.JustGaveBirth = "This reptile recently gave birth in the last month. This would explain the weight loss of " + WeightLoss + ". This is a serious amount of weight loss. This would not be normal. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                        else if (MinorWeight == true)
                        {
                            HealthStatus += 1;
                            ViewBag.JustGaveBirth = "This reptile recently gave birth in the last month. This would explain the weight loss of " + WeightLoss + ". This is a minor amount of weight loss. This would be normal. Consider seperating this reptile or a bigger diet to help gain weight. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                    }
                }
            }

            //shed check
            if (latestShed.Sheds == ShedType.Inshed || latestShed.Sheds == ShedType.Badshed || latestShed.Sheds == ShedType.Preshed)
            {
                DateTime shedDate = latestShed.Date;
                DateTime newDate = DateTime.Today;
                TimeSpan ts = shedDate - newDate;
                int diffInDays = ts.Days;

                if (diffInDays > 7)
                {
                    HealthStatus += 2;
                    ViewBag.ShedWarning = ReptileType.NickName + " is in " + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is not normal. Please read these links to help solve this issue." + "<br />" + UriLeoSheddingHelp_001 + "<br />" + UriLeoSheddingHelp_002 + "<br />" + UriLeoSheddingHelp_003 + "<br />" + UriLeoSheddingHelp_004;
                }
                else if (diffInDays > 4 & diffInDays < 6)
                {
                    HealthStatus += 1;
                    ViewBag.shedWarning = ReptileType.NickName + "is in" + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is ok. Please read these links if this issue continues. " + "<br />" + UriLeoSheddingHelp_001 + "<br />" + UriLeoSheddingHelp_002 + "<br />" + UriLeoSheddingHelp_003 + "<br />" + UriLeoSheddingHelp_004;
                }
            }

            //defication check
            DateTime defDate = latestDefication.Date;
            DateTime feedingDate = latestFeeding.Date;
            DateTime today = DateTime.Today;
            TimeSpan Deftimes = defDate - today;
            TimeSpan Feedtimes = feedingDate - today;
            int DiffDefInDays = Deftimes.Days;
            int diffInFeeding = Feedtimes.Days;
            if (DiffDefInDays > 7)
            {
                HealthStatus += 2;
                if (diffInFeeding > 5)
                {
                    ViewBag.DeficationMessage = ReptileType.NickName + " Has not passed soilds in " + DiffDefInDays + " days, this is a seriours condition for" + ReptileType.ScientificName + ". Althought the reptile has not feed in the past " + diffInFeeding + "days this could explain the issue.Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                }
                else
                {
                    ViewBag.DeficationMessage = ReptileType.NickName + " Has not passed soilds in " + DiffDefInDays + " days, this is a seriours condition for" + ReptileType.ScientificName + "Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                }

            }
            else if (DiffDefInDays > 2 & DiffDefInDays < 5)
            {
                HealthStatus += 1;
                ViewBag.DeficationMessage = ReptileType.NickName + " has not passed solids in " + DiffDefInDays + " days.This is not to serious but if this does not change consider bringing the reptile to the vet. Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
            }

            //length check
            // 1-2 months
            if (ReptileType.Born.Value.AddMonths(1) > DateTime.Today & ReptileType.Born.Value.AddMonths(2) < DateTime.Today.AddDays(30))
            {
                if (latestLength.Lengths < 3)
                {

                    HealthStatus += 2;
                    ViewBag.LengthIssue = ReptileType.CommonName + " is below the average size for its' age, please follow these links on caring for young " + ReptileType.SpeciesName + ". Helpful links " + UriBabyLeoHelp_001 + "<br />" + UriBabyLeoHelp_002;

                }
            }
            // 3-6 months
            else if (ReptileType.Born.Value.AddMonths(3) > DateTime.Today & ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
            {
                if (latestLength.Lengths < 4)
                {
                    HealthStatus += 2;
                    ViewBag.LengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.SpeciesName + ". Helpful links" + "<br />" + UriJuvenileLeoHelp_001 + "<br />" + UriJuvenileLeoHelp_002;
                }
            }
            // greater than 6 months
            else if (ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
            {
                if (latestLength.Lengths < 7)
                {
                    HealthStatus += 2;
                    ViewBag.LengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.SpeciesName + ".<br /> Helpful links" + "<br />  <a href=" + UriJuvenileLeoHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriJuvenileLeoHelp_002 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoHelp_001 + " " + target + ">Leopard Gecko Health</a>";

                }
            }
            var colour = "";

            if (HealthStatus == 0)
                 {
                     colour = "#7EBF7E";
                 }
            else if (HealthStatus >= 1 || HealthStatus <= 2)
                  {
                      colour = "#FFFF66";
            }
          else if (HealthStatus  <= 4)
                 {
                     colour = "#FFCC00";
            }
            else if (HealthStatus == 6)
        {
            colour = "#FF9900";
          }
        else if (HealthStatus == 8)
        {
            colour = "#FF0000";
           }
            else if (HealthStatus == 10)
            {

                colour = "#000000";
              }
            ViewBag.Health = HealthStatus;
            return colour;
        }
       
        // cannot be async :( 
        public ActionResult HealthStatus(string id)
        {
           int HealthStatus = 0;
            

            var ReptileType =  db.Reptiles.FirstOrDefault(x => x.ReptileId == id);

            var latestWeight = db.Weights.OrderByDescending(w => w.Date).Where(r => r.ReptileId == id);
              
            
            var latestFeeding =  db.Feedings.FirstOrDefault(f => f.ReptileId == id);
            var latestLength =  db.Lengths.FirstOrDefault(l => l.ReptileId == id);
            var latestDefication =  db.Defications.FirstOrDefault(d => d.ReptileId == id);
            var latestShed =  db.Sheds.FirstOrDefault(s => s.ReptileId == id);

            
            List<Weight> WeightList = new List<Weight>();
           
            foreach (var w in latestWeight)
            {
                WeightList.Add(w);
            }

           


            //danger weight list to be implemented
            int DangerWeightLoss = 15;
            int MinorWeightLoss = 5;
            bool DangerWeight = false;
            bool MinorWeight = false;
            var WeightLoss = 0;


            // used for links to open in new window
            String newLink = "target=";
            String target = newLink+"_blank";

            Uri UriLeoHelp_001 = new Uri("http://www.geckosetc.com/htm/health.htm");

            // baby help
            Uri UriBabyLeoHelp_001 = new Uri("http://www.thegeckospot.net/leohatchlingcare.php");
             Uri UriBabyLeoHelp_002 = new Uri("http://www.wbeph.com/reptiles/keeping-leopard-geckoes-in-phoenix-arizona/");
           
            // Juvenile help
            Uri UriJuvenileLeoHelp_001 = new Uri("http://www.reptilesmagazine.com/Care-Sheets/Lizards/Leopard-Gecko/");
            Uri UriJuvenileLeoHelp_002 = new Uri("http://www.theurbangecko.com/caring-leopard-gecko");

            //breeding help
            Uri UriLeoBreedingHelp_001 = new Uri("http://www.vmsherp.com/LCBreedingLeopards.htm");
            Uri UriLeoBreedingHelp_002 = new Uri("http://www.thegeckospot.net/leobreeding.php");

            //shedding help
             Uri UriLeoSheddingHelp_001 = new Uri("http://www.leopardgeckos.co.za/health-leopard-gecko-shedding-problems.htm");
             Uri UriLeoSheddingHelp_002 = new Uri("http://www.universityvet.com/resource/eye-and-skin-problems-leopard-geckos");
             Uri UriLeoSheddingHelp_003 = new Uri("http://geckocare.net/leopard-gecko-shedding/");
             Uri UriLeoSheddingHelp_004 = new Uri("http://www.leopardgeckomorphcalculator.co.uk/Help/LeopardGeckoShedding.aspx");

            // defication help
            Uri UriLeoDeficationHelp_001 = new Uri("http://leopardgeckogal.hubpages.com/hub/What-to-do-if-your-leopard-gecko-wont-poop");
            Uri UriLeoDeficationHelp_002 = new Uri("http://www.repticzone.com/forums/Geckos-Leopard/messages/177497.html");
            Uri UriLeoDeficationHelp_003 = new Uri("https://www.youtube.com/watch?v=wvpcPS8k09c");

           

         
             //weight check
            var LastFiveWeights = WeightList.OrderByDescending(x => x.Date).Take(5);
           
            for (int i = 0; i < LastFiveWeights.Count(); i++)
            {
                if (ReptileType.Born.Value.AddDays(30) <= DateTime.Today)
                {
                    break;
                }
                else
                {
                    // 1-2 months
                    if (ReptileType.Born.Value.AddMonths(1) > DateTime.Today & ReptileType.Born.Value.AddMonths(2) < DateTime.Today.AddDays(30))
                    {
                        if (LastFiveWeights.FirstOrDefault().Weights < 2)
                        {
                            HealthStatus += 2;
                            ViewBag.WeightLossMessage = ReptileType.CommonName + " has not gained much weight, please follow these links on caring for young " + ReptileType.SpeciesName + ". " + "<br />" + UriBabyLeoHelp_001 + "<br />" + UriBabyLeoHelp_002;
                            break;
                        }
                    }
                    // 3-6 months
                    else if (ReptileType.Born.Value.AddMonths(3) > DateTime.Today & ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
                    {
                        if (WeightList.FirstOrDefault().Weights < 5)
                        {
                            HealthStatus += 2;
                            ViewBag.WeightLossMessage = ReptileType.NickName + " has not gained much weight, this is serious because of the age " + ReptileType.Born + " please follow these links on caring for young " + ReptileType.SpeciesName + ". " + "<br />" + UriJuvenileLeoHelp_001 + "<br />" + UriJuvenileLeoHelp_002;
                            break;
                        }
                    }
                        // greater than 6 months
                    else if (ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
                    {
                        if (LastFiveWeights.ElementAt(i).Weights > LastFiveWeights.First().Weights)
                        {
                            WeightLoss = LastFiveWeights.Last().Weights - LastFiveWeights.First().Weights;

                            System.Diagnostics.Debug.WriteLine(LastFiveWeights.Last()); // test to check order of list

                            if (WeightLoss >= DangerWeightLoss)
                            {
                                DangerWeight = true;
                                HealthStatus += 2;
                                ViewBag.WeightLossMessage = "ID:" + id + " has lost " + WeightLoss + ". This is very seriours. Helpful links:" + UriLeoHelp_001.ToString();

                            }
                            else if (WeightLoss < MinorWeightLoss)
                            {
                                MinorWeight = true;
                                HealthStatus += 1;
                                ViewBag.WeightLossMessage = "ID:" + id + " has lost " + WeightLoss + ". This reptile requires attention. Helpful links:" + UriLeoHelp_001.ToString();
                            }
                        }
                    }
                }
            }
             //breeding check
            if(HealthStatus > 0)
            {
                if (ReptileType.Gender == Gender.Female)
                {
                    DateTime start = ReptileType.DueDate;
                    DateTime newDate = DateTime.Today;
                    TimeSpan ts = newDate - start;
                    int differenceInDays = ts.Days;

                    if(differenceInDays < 14)
                    {
                        if (DangerWeight == true)
                        {
                            HealthStatus += 2;
                            ViewBag.JustGaveBirth = "This reptile just gave birth in the last two week. This would explain the weight loss of " + WeightLoss + ". This is a serious amount of weight loss. Please reconsider breeding this reptile. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                        else if(MinorWeight == true)
                        {
                            HealthStatus += 1;
                            ViewBag.JustGaveBirth = "This reptile just gave birth in the last two week. This would explain the weight loss of " + WeightLoss + ". This is a minor amount of weight loss. This would be normal. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                    }
                    else if (differenceInDays > 14 & differenceInDays < 28)
                    {
                        if(DangerWeight == true)
                        {
                            HealthStatus += 2;
                            ViewBag.JustGaveBirth = "This reptile recently gave birth in the last month. This would explain the weight loss of " + WeightLoss + ". This is a serious amount of weight loss. This would not be normal. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                        else if(MinorWeight == true)
                        {
                            HealthStatus += 1;
                            ViewBag.JustGaveBirth = "This reptile recently gave birth in the last month. This would explain the weight loss of " + WeightLoss + ". This is a minor amount of weight loss. This would be normal. Consider seperating this reptile or a bigger diet to help gain weight. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                        }
                     }
                }
            }

             //shed check
            if (latestShed.Sheds == ShedType.Inshed || latestShed.Sheds == ShedType.Badshed || latestShed.Sheds == ShedType.Preshed)
            {
                DateTime shedDate = latestShed.Date;
                DateTime newDate = DateTime.Today;
                TimeSpan ts = shedDate - newDate;
                int diffInDays = ts.Days;
        
                if(diffInDays > 7)
                {
                    HealthStatus += 2;
                    ViewBag.ShedWarning = ReptileType.NickName + " is in " + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is not normal. Please read these links to help solve this issue." + "<br />" + UriLeoSheddingHelp_001 + "<br />" + UriLeoSheddingHelp_002 + "<br />" + UriLeoSheddingHelp_003 + "<br />" + UriLeoSheddingHelp_004;
                }
                else if(diffInDays > 4 & diffInDays < 6)
                {
                    HealthStatus += 1;
                    ViewBag.shedWarning = ReptileType.NickName + "is in" + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is ok. Please read these links if this issue continues. " + "<br />" + UriLeoSheddingHelp_001 + "<br />" + UriLeoSheddingHelp_002 + "<br />" + UriLeoSheddingHelp_003 + "<br />" + UriLeoSheddingHelp_004;
                }
            }
            
             //defication check
            DateTime defDate = latestDefication.Date;
            DateTime feedingDate = latestFeeding.Date;
            DateTime today = DateTime.Today;
            TimeSpan Deftimes = defDate - today;
            TimeSpan Feedtimes = feedingDate - today;
            int DiffDefInDays = Deftimes.Days;
            int diffInFeeding = Feedtimes.Days;
            if (DiffDefInDays > 7)
            {
                HealthStatus += 2;
                if (diffInFeeding > 5)
                {
                   ViewBag.DeficationMessage = ReptileType.NickName + " Has not passed soilds in "+DiffDefInDays+" days, this is a seriours condition for" + ReptileType.ScientificName + ". Althought the reptile has not feed in the past "+diffInFeeding+"days this could explain the issue.Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                }
                else
                {
                    ViewBag.DeficationMessage = ReptileType.NickName + " Has not passed soilds in "+DiffDefInDays+" days, this is a seriours condition for" + ReptileType.ScientificName + "Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                }
                
            }
            else if (DiffDefInDays > 2 & DiffDefInDays < 5)
            {
                HealthStatus += 1;
                ViewBag.DeficationMessage = ReptileType.NickName + " has not passed solids in " + DiffDefInDays + " days.This is not to serious but if this does not change consider bringing the reptile to the vet. Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
            }

            //length check
            // 1-2 months
             if (ReptileType.Born.Value.AddMonths(1) > DateTime.Today & ReptileType.Born.Value.AddMonths(2) < DateTime.Today.AddDays(30))
                    {
                        if (latestLength.Lengths  < 3 )
                        {
                           
                            HealthStatus += 2;
                            ViewBag.LengthIssue = ReptileType.CommonName + " is below the average size for its' age, please follow these links on caring for young " + ReptileType.SpeciesName + ". Helpful links " + UriBabyLeoHelp_001+"<br />"+UriBabyLeoHelp_002;
                            
                        }
                    }
                    // 3-6 months
                    else if (ReptileType.Born.Value.AddMonths(3) > DateTime.Today & ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
                    {
                        if (latestLength.Lengths < 4)
                        {
                            HealthStatus += 2;
                            ViewBag.LengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.SpeciesName + ". Helpful links" + "<br />" + UriJuvenileLeoHelp_001 + "<br />" + UriJuvenileLeoHelp_002;
                        }
                    }
                        // greater than 6 months
             else if (ReptileType.Born.Value.AddMonths(6) < DateTime.Today)
             {
                 if (latestLength.Lengths < 7)
                 {
                     HealthStatus += 2;
                     ViewBag.LengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.SpeciesName + ".<br /> Helpful links" + "<br />  <a href=" + UriJuvenileLeoHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriJuvenileLeoHelp_002 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoHelp_001 + " " + target + ">Leopard Gecko Health</a>"; 

                 }
             }
             ViewBag.Health = HealthStatus;
            return PartialView();
         }
        
	    public async Task<ActionResult> Images(string id)
         {
          
          ViewBag.Message = "Your Qr codes for this reptile";
          var QrCodeToRetrieve = await db.Reptiles.FindAsync(id);

        //  var convertedImage = QrCodeToRetrieve.byteArrayToImage(QrCodeToRetrieve.QRCode);

          byte[] imgBytes = QrCodeToRetrieve.QRCode;
          
          
            return File(imgBytes,"image/png");
          }

       


/*
       public async Task<ActionResult> MatingDetails(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Mating mating = await db.Matings.FindAsync(id);
           if (mating == null)
           {
               return HttpNotFound();
           }
           return View(mating);
       }
 * */

      

        // GET: Reptiles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           //code for reptile details,image and mating table
            Reptile reptile = await db.Reptiles.Include(r => r.Files).Include(r=>r.Matings).FirstOrDefaultAsync(r => r.ReptileId == id);

            //code for d3
            var reptiles =  db.Reptiles.Select(r => new {Weight = r.Weights});

         //   var mating = db.Reptiles.Select(r => new { Matings = r.Matings });
            object[] weightArray = new object[2];
            foreach(var data in reptiles)
            {
                var weightData = data.Weight;
                foreach(var values in weightData)
                {
                    weightArray[0] = values.Weights;
                    weightArray[1] = values.Date;
                }
            }
            
          //  string json = JsonConvert.SerializeObject(weightArray);
            ViewBag.Json = weightArray;
           // var d3query = await db.Matings.ToListAsync();
           // string json = JsonConvert.SerializeObject(d3query);
        
           // Reptile rep = await db.Reptiles.FindAsync(id);

           // Reptile mating = await db.Reptiles.Include(r => r.Matings).SingleOrDefaultAsync(r => r.ReptileId == id);
     
            //var join = from reptile in db.Reptiles join m in db.Matings on reptile.ReptileId equals m.ReptileId into g where reptile.ReptileId.Equals(id)select new{Mating = g.SelectMany(d =>d.Date,d =>d.Event))}

          /* Mating mating = db.Reptiles.SelectMany(r => r.Matings)
                        .Select(o => new
                        {
                            ReptileId = o.Reptile.ReptileId,
                            Date = o.date,
                            Event = o.Event
                        });
           */
         //   ParentView parentView = new ParentView();
            
           
        //   parentView.Reptiles = reptile;
           //parentView.Matings = ;
            
           // Mating mating = await db.Matings.Include(r => r.).Where(r => r.ReptileId == id);
            // return all mating details assocaited with this ID and pass them to the view
 
           // var matingList = db.Matings.Where(m => m.mateID.Contains(id)).Select(d => new { d.Date, d.Event }).ToListAsync();

          //  ViewData["mating"] = matingList;

            if (reptile == null)
            {
                return HttpNotFound();
            }
            
            return View(reptile);
           
        }

       

        // GET: Reptiles/Create
      //  [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reptiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
     //   [Authorize(Roles = "canEdit")]
        public async Task<ActionResult> Create([Bind(Include = "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,TimeStamp,DueDate,TubeBoxNumber,Note,SalesCardComment")] Reptile reptile, HttpPostedFileBase upload)
        {
            try
            {

            
                if (ModelState.IsValid)
                {

                    if (upload != null && upload.ContentLength > 0)
                    {
                        var image = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.image,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            
                            image.Content = reader.ReadBytes(upload.ContentLength);
                           
                        }
                       
                        reptile.Files = new List<File> { image };
                    }
                    //creates qr code and saves it as binary data
                    var newQr = reptile.QrGen();

                    var byteContent = reptile.imageToByteArray(newQr);
                    reptile.QRCode = byteContent;


                    reptile.TimeStamp = DateTime.Today.ToLocalTime();
                    
                    db.Reptiles.Add(reptile);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException  /*dex*/ )
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                //dex.GetBaseException();
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
        
            return View(reptile);
        }

        // GET: Reptiles/Edit/5
       //  [Authorize(Roles = "canEdit")]
        public  async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.Include(r => r.Files).SingleOrDefaultAsync(r => r.ReptileId == id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // POST: Reptiles/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(string id,[Bind(Include = "ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment")] Reptile reptile,HttpPostedFileBase upload)
        {
            if(reptile.ReptileId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reptileToUpdate = await db.Reptiles.FindAsync(id);
           if(TryUpdateModel(reptileToUpdate,"", new string[] {"ReptileId,Gender,SpeciesName,ScientificName,CommonName,Born,Morph,Venomous,Weight,WeightProgress,Origin,Food,FeedingType,AdultSize,Habitat,Breeder,BreederEmail,Cities,ClutchID,ForSale,Price,NickName,LicenseNumber,ChipNumber,SpeciesNumber,FatherNotInDb,MotherNotInDb,FeedInterval,DueDate,TubeBoxNumber,Note,SalesCardComment"}))
           {
               try
               {
                   if(upload != null && upload.ContentLength > 0)
                   {
                       if (reptileToUpdate.Files.Any(f => f.FileType == FileType.image))
                       {
                           db.Files.Remove(reptileToUpdate.Files.First(f => f.FileType == FileType.image));
                       }
                       var image = new File
                       {
                           FileName = System.IO.Path.GetFileName(upload.FileName),
                           FileType = FileType.image,
                           ContentType = upload.ContentType
                       };
                       using (var reader = new System.IO.BinaryReader(upload.InputStream))
                       {
                           image.Content = reader.ReadBytes(upload.ContentLength);
                       }
                       reptileToUpdate.Files = new List<File> { image };
                   }
                    db.Entry(reptileToUpdate).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
               }
               catch (RetryLimitExceededException /* dex */)
               {
                   //Log the error (uncomment dex variable name and add a line here to write a log.
                   ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
               }
           }
            return View(reptileToUpdate);
        }

        // GET: Reptiles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // POST: Reptiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                Reptile reptile = await db.Reptiles.FindAsync(id);
                foreach (var entry in reptile.Files.ToList())
                {
                    db.Files.Remove(entry);
                }
                db.Reptiles.Remove(reptile);
                await db.SaveChangesAsync();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        // GET: Matings/Create
        public async Task<ActionResult> Mating(string id,Mating mating)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
          
           // ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "ReptileId", mating.ReptileId);
            mating.ReptileId = reptile.ReptileId;
            return View(mating);
          
           
            
        }

        // POST: Matings/Create
      
        // fix error issue 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Mating([Bind(Include = "MatingId,Event,Date,mateID,ReptileId")] Mating mating)
        {
           /* if(mating.mateID.Equals(mating.ReptileId))
            {
                ViewBag.Message = "Reptiles have the same ID, please make sure they are different";
                
                return View(mating);
            }
            else */
            if (ModelState.IsValid)
            {
                db.Matings.Add(mating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

        // ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "ReptileId",mating.ReptileId);
            
            return View(mating);
        }
       
        // GET: Notifications/Create
        public async Task<ActionResult> Notification(string id, Notification notifi)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            notifi.ReptileId = reptile.ReptileId;
            return View(notifi);
        }

        // POST: Notifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Notification([Bind(Include = "NotificationId,Description,Message,SendAt,ReptileId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            
            return View(notification);
        }
        
        // GET: Other/Create
        public async Task<ActionResult> Other(string id,Other other)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            other.ReptileId = reptile.ReptileId;
            return View(other);
        }

        // POST: Other/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Other([Bind(Include = "OtherId,Date,Newaction,Notes,ReptileId")] Other other)
        {
            if (ModelState.IsValid)
            {
                db.Other.Add(other);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

          
            return View(other);
        }

        // GET: Medications/Create
        // 
        public async Task<ActionResult> Medication(string id, Medication medication)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            medication.ReptileId = reptile.ReptileId;
            return View(medication);
        }

        // POST: Medications/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Medication([Bind(Include = "MedicationId,Date,MedicationField,Notes,ReptileId")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                db.Medications.Add(medication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            
            return View(medication);
        }

        // GET: Sheds/Create
        public async Task<ActionResult> Shed(string id,Shed shed)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            shed.ReptileId = reptile.ReptileId;
            return View(shed);
        }

        // POST: Sheds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Shed([Bind(Include = "ShedId,Date,Sheds,Notes,ReptileId")] Shed shed)
        {
            if (ModelState.IsValid)
            {
                db.Sheds.Add(shed);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           
            return View(shed);
        }

        // GET: Defications/Create
        // inside reptile controller
        public async Task<ActionResult> Defication(string id, Defication defica)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            defica.ReptileId = reptile.ReptileId;
            return View(defica);
          
        }

        // POST: Defications/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Defication([Bind(Include = "DeficationId,Date,Defications,Notes,ReptileId")] Defication defication)
        {
            if (ModelState.IsValid)
            {
                db.Defications.Add(defication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

          
            return View(defication);
        }

        // GET: Cleanings/Create
           public async Task<ActionResult> Cleaning(string id, Cleaning clean)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Reptile reptile = await db.Reptiles.FindAsync(id);
               if (reptile == null)
               {
                   return HttpNotFound();
               }
               clean.ReptileId = reptile.ReptileId;
               return View(clean);
           }

           // POST: Cleanings/Create
           // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
           // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<ActionResult> Cleaning([Bind(Include = "CleaningId,Date,Cleanings,Notes,ReptileId")] Cleaning cleaning)
           {
               if (ModelState.IsValid)
               {
                   db.Cleanings.Add(cleaning);
                   await db.SaveChangesAsync();
                   return RedirectToAction("Index");
               }

             
               return View(cleaning);
           }
           // GET: Feedings/Create
           public async Task<ActionResult> Feeding(string id, Feeding feed)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Reptile reptile = await db.Reptiles.FindAsync(id);
               if (reptile == null)
               {
                   return HttpNotFound();
               }
               feed.ReptileId = reptile.ReptileId;
               feed.Date = DateTime.Today.ToLocalTime();
               return View(feed);
           }

           // POST: Feedings/Create
           
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<ActionResult> Feeding([Bind(Include = "FeedingId,Date,Feedings,FoodSize,NumItemsFed,Notes,ReptileId")] Feeding feeding)
           {
               /*   add this later
               if(feeding.Feedings == null || feeding.FoodSize == null)
               {
                   ViewBag.Message = "Please select food size or food type.";
               }
                * */
               if (ModelState.IsValid)
               {
                  Reptile updateTimeStamp =  await db.Reptiles.FirstOrDefaultAsync(r => r.ReptileId == feeding.ReptileId);
                   updateTimeStamp.TimeStamp = feeding.Date.ToUniversalTime();
                   db.Reptiles.Attach(updateTimeStamp);
                   db.Entry(updateTimeStamp).Property(r => r.TimeStamp).IsModified = true;

                   db.Feedings.Add(feeding);
                   await db.SaveChangesAsync();
                   return RedirectToAction("Index");
               }

              
               return View(feeding);
           }
           
        // GET: BreedingCycles/Create
       public async Task<ActionResult> BreedingCycle(string id,BreedingCycle BreedCyc)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            BreedCyc.ReptileId = reptile.ReptileId;
            return View(BreedCyc);
        }

        // POST: BreedingCycles/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BreedingCycle([Bind(Include = "BreedingCycleId,Date,BreedStage,Notes,ReptileId")] BreedingCycle breedingCycle)
        {
            if (ModelState.IsValid)
            {
                db.BreedingCycles.Add(breedingCycle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReptileId = new SelectList(db.Reptiles, "ReptileId", "ReptileId", breedingCycle.ReptileId);
            return View(breedingCycle);
        }

         // GET: Ultrasounds/Create
         public async Task<ActionResult> Ultrasound(string id, Ultrasound ultras)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            ultras.ReptileId = reptile.ReptileId;
            return View(ultras);
           
        }

        // POST: Ultrasounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<ActionResult> Ultrasound([Bind(Include = "UltrasoundId,Date,Ultrasounds,Count,FollicleSize,Notes,ReptileId")] Ultrasound ultrasound)
        {
            if (ModelState.IsValid)
            {
                db.Ultrasounds.Add(ultrasound);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

          
            return View(ultrasound);
        }

        // GET: Notes/Create
        public async Task<ActionResult> Note(string id,Note note)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            note.ReptileId = reptile.ReptileId;
            return View(note);
            
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Note([Bind(Include = "NoteId,Notes,CategNote,ReptileId")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

      
            return View(note);
        }

        // GET: Weights/Create
       
       public async Task<ActionResult> Weight(string id, Weight weight)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            weight.ReptileId = reptile.ReptileId;
            return View(weight);
        }

        // POST: Weights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Weight([Bind(Include = "WeightId,Weights,Date,ReptileId")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                db.Weights.Add(weight);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

         
            return View(weight);
        }
        //get
        public async Task<ActionResult> Length(string id,Length length)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = await db.Reptiles.FindAsync(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            length.ReptileId = reptile.ReptileId;
            return View(length);
        }

        // POST: Lengths/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Length([Bind(Include = "LengthId,Lengths,Date,ReptileId")] Length length)
        {
            if (ModelState.IsValid)
            {
                db.Lengths.Add(length);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
         
            return View(length);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
