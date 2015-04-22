using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using ReptileManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ReptileManager.Services
{
    public class ReptileCharts
    {
        private ReptileContext db = new ReptileContext();
        public Charts chart(String id)
        {
            using (db)
            {
                var reptileType = db.Reptiles.FirstOrDefault(r => r.ReptileId == id);
                var weights = (from w in db.Weights where w.ReptileId == id select w.Weights);
                var feedings = (from f in db.Feedings where f.ReptileId == id select f.NumItemsFed);
                var lengths = (from l in db.Lengths where l.ReptileId == id select l.Lengths);

                Object[] AvgForSpecies = new Object[12];
                DateTime newDate = DateTime.UtcNow;
                DateTime born = reptileType.Born.Value;
                TimeSpan ts = newDate - born;
                int age = ts.Days;
                if (age > 365)
                {
                    AvgForSpecies = new Object[12];
                }
                else
                {
                    if (reptileType.ScientificName.Equals("Python regius"))
                    {

                        AvgForSpecies = new Object[]
                        { 61.73,
                          82.20,
                         146.47,
                         230.33,
                         288.20,
                         346.40,
                         377.87,
                         406.20,
                         445.20,
                         476.73,
                         506.27,
                         546,
                     };

                    }
                    else if (reptileType.ScientificName.Equals("Eublepharis macularius"))
                    {

                        AvgForSpecies = new Object[]
                    {
                       2,
                       4,
                       5.5,
                       7.23,
                       9,
                       12.43,
                       15.98,
                       17,
                       18.96,
                       24,
                       30,
                       37,
                    };
                    }
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
                    .SetCredits(new Credits { Enabled = false })
                   .SetXAxis(new XAxis { Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } })
                   .SetYAxis(new YAxis
                   {

                       Title = new YAxisTitle { Text = "grams" }
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
                    new Series {Color = ColorTranslator.FromHtml("#87CEFA"),Name = "Feedings", Data = new Data(newFeedingsObj)},
                    new Series {Color = ColorTranslator.FromHtml("#FF66FF") ,Name = "Weight", Data = new Data(newWeightsObj)},
                    new Series {Color = ColorTranslator.FromHtml("#6C7A89") ,Name = "Average", Data = new Data(AvgForSpecies)}
                });

                Highcharts g1 = new Highcharts("chart1")
                     .InitChart(new Chart { Type = ChartTypes.Areaspline })
                     .SetTitle(new Title { Text = "Weights for each month " })
                       .SetCredits(new Credits { Enabled = false })
                   .SetXAxis(new XAxis
                   {
                       Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                       Title = new XAxisTitle { Text = "Months" }
                   })
                    .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Weight units" } })
                    .SetSeries(new[]
                {
                    new Series {  Name = "Weights", Data = new Data(newWeightsObj)},
               
                    new Series {  Color = ColorTranslator.FromHtml("#6C7A89"),Name = "Average", Data = new Data(AvgForSpecies)},
                
                   
               });

                Highcharts g3 = new Highcharts("chart3")
                   .InitChart(new Chart { Type = ChartTypes.Areaspline })
                   .SetTitle(new Title { Text = "Length for each month " })
                   .SetCredits(new Credits { Enabled = false })
                   .SetXAxis(new XAxis
                 {
                     Title = new XAxisTitle { Text = "Months" },
                     Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }

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

                return model;
            }
        }
    }
}