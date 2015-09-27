using ReptileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReptileManager.Services
{
    
    public class HealthStatus
    {
        private ReptileContext db = new ReptileContext();
        public Tuple<String, List<String>> GetHealth(String id)
        {
            int HealthStatus = 0;
            String colour = "";
            List<String> report = new List<String>();

            using (db)
            {
                var ReptileType = db.Reptiles.FirstOrDefault(x => x.ReptileId == id);
                
                var latestWeight = db.Weights.OrderByDescending(w => w.Date).Where(r => r.ReptileId == id);


                var latestFeeding = db.Feedings.FirstOrDefault(f => f.ReptileId == id);
                var latestLength = db.Lengths.OrderByDescending(w => w.Date).FirstOrDefault(l => l.ReptileId == id);
                var latestDefication = db.Defications.FirstOrDefault(d => d.ReptileId == id);
                var latestShed = db.Sheds.FirstOrDefault(s => s.ReptileId == id);

             
               List<Weight> WeightList = new List<Weight>();

                foreach (var w in latestWeight)
                {
                    WeightList.Add(w);
                }

                //danger weight list to be implemented
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
                String weightLossMessage;
                var LastFiveWeights = WeightList.Take(5);

                DateTime born = ReptileType.Born.Value;
                DateTime newDate = DateTime.UtcNow;

                TimeSpan tsAge = newDate - born;
                int age = tsAge.Days;

                var dictionary = new Dictionary<string, HealthStatusVariables>
                           {
	                         {"Python regius", new HealthStatusVariables(40,100,125,75,28,56,5,10,15,28,56,65,10,24,36)},
	                         {"Eublepharis macularius", new HealthStatusVariables(2,5,15,5,14,28,4,6,7,2,5,7,3,4,7)}
                           };





               if (dictionary.ContainsKey(ReptileType.ScientificName.ToString()))
               {
                   HealthStatusVariables reptile;
                   dictionary.TryGetValue(ReptileType.ScientificName.ToString(), out reptile);
                   int count = 0;
                   for (int i = 0; i < LastFiveWeights.Count(); i++)
                   {
                       if (age <= 30)
                       {
                           break;
                       }
                       else
                       {
                           // 1-2 months
                           if (age > 30 & age <= 60)
                           {
                               if (LastFiveWeights.FirstOrDefault().Weights < reptile.BabyWeight)
                               {
                                   DangerWeight = true;
                                   HealthStatus += 2;
                                   weightLossMessage = ReptileType.CommonName + " has not gained much weight, please follow these links on caring for young " + ReptileType.CommonName + ". " + "<br />" + UriBabyLeoHelp_001 + "<br />" + UriBabyLeoHelp_002;
                                   report.Add(weightLossMessage);
                                   break;
                               }
                           }
                           // 3-6 months
                           else if (age > 61 & age < 182)
                           {
                               if (WeightList.FirstOrDefault().Weights < reptile.JuvinileWeight)
                               {
                                   DangerWeight = true;
                                   HealthStatus += 2;
                                   weightLossMessage = ReptileType.NickName + " has not gained much weight, this is serious because of" +ReptileType.Gender.ToString() + ReptileType.Born.Value.ToShortDateString() + " please follow these links on caring for young " + ReptileType.ScientificName + ". " + "<br />  <a href=" + UriJuvenileLeoHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriJuvenileLeoHelp_002 + " " + target + ">Care Sheet</a>";
                                   report.Add(weightLossMessage);
                                   break;
                               }
                           }
                           // greater than 6 months
                           else if (age > 182)
                           {
                               if (LastFiveWeights.ElementAt(i).Weights > LastFiveWeights.First().Weights)
                               {
                                   WeightLoss = LastFiveWeights.ElementAt(i).Weights - LastFiveWeights.First().Weights;

                                   if (WeightLoss >= reptile.DangerWeightLoss)
                                   {

                                       weightLossMessage = ReptileType.NickName + " has lost " + WeightLoss + " grams. Since " + LastFiveWeights.ElementAt(i).Date.ToShortDateString() + " This is very seriours.<br /> Helpful links:" + "<br />  <a href=" + UriLeoHelp_001 + " " + target + ">General Help</a>";
                                       report.Add(weightLossMessage);
                                       if (count < 1)
                                       {
                                           HealthStatus += 2;
                                           DangerWeight = true;
                                           count++;
                                       }

                                   }
                                   else if (WeightLoss >= reptile.MinorWeightLoss && WeightLoss <= reptile.MinorWeightLoss)
                                   {
                                       if (count < 1)
                                       {
                                           MinorWeight = true;
                                           HealthStatus += 1;
                                           count++;
                                       }
                                       weightLossMessage = ReptileType.NickName + " has lost " + WeightLoss + " grams.Since " + LastFiveWeights.ElementAt(i).Date.ToShortDateString() + " This reptile requires attention.<br /> Helpful links:" + "<br />  <a href=" + UriLeoHelp_001 + " " + target + ">General Help</a>";
                                       report.Add(weightLossMessage);
                                   }
                               }
                           }
                       }

                   }

                   //breeding check
                   String justGaveBirth;
                   if (HealthStatus > 0)
                   {
                       if (ReptileType.Gender == Gender.Female)
                       {
                           DateTime start = ReptileType.DueDate;
                           TimeSpan ts = newDate - start;
                           int differenceInDays = ts.Days;

                           if (differenceInDays < reptile.DaySinceBirthLong)
                           {
                               if (DangerWeight == true)
                               {
                                   HealthStatus += 2;
                                   justGaveBirth = "This reptile gave birth on "+ReptileType.DueDate.ToShortDateString()+". This would explain the weight loss of " + WeightLoss + " grams. This is a serious amount of weight loss. Please reconsider breeding this reptile. Please read these links on caring for " + ReptileType.ScientificName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                   report.Add(justGaveBirth);
                               }
                               else if (MinorWeight == true)
                               {
                                   HealthStatus += 1;
                                   justGaveBirth = "This reptile  gave birth on" + ReptileType.DueDate.ToShortDateString() + ". This would explain the weight loss of " + WeightLoss + " grams. This is a minor amount of weight loss. This would be normal. Please read these links on caring for " + ReptileType.ScientificName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                   report.Add(justGaveBirth);
                               }
                           }
                           else if (differenceInDays > reptile.DaySinceBirth & differenceInDays < reptile.DaySinceBirthLong)
                           {
                               if (DangerWeight == true)
                               {
                                   HealthStatus += 2;
                                   justGaveBirth = "This reptile birth on " + ReptileType.DueDate.ToShortDateString() + ". This would explain the weight loss of " + WeightLoss + " grams. This is a serious amount of weight loss. This would not be normal. Please read these links on caring for " + ReptileType.ScientificName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                   report.Add(justGaveBirth);
                               }
                               else if (MinorWeight == true)
                               {
                                   HealthStatus += 1;
                                   justGaveBirth = "This reptile birth on " + ReptileType.DueDate.ToShortDateString() + ". This would explain the weight loss of " + WeightLoss + " grams. This is a minor amount of weight loss. This would be normal. Consider seperating this reptile or a bigger diet to help gain weight. Please read these links on caring for " + ReptileType.ScientificName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                   report.Add(justGaveBirth);
                               }
                           }
                       }
                   }

                   //shed check
                   String shedWarning;

                   if (latestShed.Sheds == ShedType.Inshed || latestShed.Sheds == ShedType.Badshed || latestShed.Sheds == ShedType.Preshed)
                   {
                       DateTime shedDate = latestShed.Date;
                       TimeSpan ts = newDate - shedDate;
                       int diffInDays = ts.Days;

                       if (diffInDays > reptile.ShedLong)
                       {
                           HealthStatus += 2;
                           shedWarning = ReptileType.NickName + " is in " + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is not normal. Please read these links to help solve this issue." + "<br />  <a href=" + UriLeoSheddingHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriLeoSheddingHelp_002 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoSheddingHelp_003 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoSheddingHelp_004 + " " + target + ">Leopard Gecko shedding</a>";

                           report.Add(shedWarning);
                       }
                       else if (diffInDays > reptile.ShedShort & diffInDays < reptile.ShedMedium)
                       {
                           HealthStatus += 1;
                           shedWarning = ReptileType.NickName + "is in" + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is ok. Please read these links if this issue continues. " + "<br />  <a href=" + UriLeoSheddingHelp_001 + " " + target + ">General Shedding help</a> <br />  <a href=" + UriLeoSheddingHelp_002 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoSheddingHelp_003 + " " + target + ">General  help</a> <br />  <a href=" + UriLeoSheddingHelp_004 + " " + target + ">YouTube video</a>";
                           report.Add(shedWarning);
                       }
                   }

                   //defication check
                   String deficationMessage;
                   DateTime defDate = latestDefication.Date;
                   DateTime feedingDate = latestFeeding.Date;
                   // System.Diagnostics.Debug.WriteLine(latestFeeding.Date +"   " +ReptileType.ReptileId+ ReptileType.ReptileId+"Hello-----------feeding date"); // test to check order of list

                   TimeSpan Deftimes = newDate - defDate;
                   TimeSpan Feedtimes = newDate - feedingDate;
                   int DiffDeficationInDays = Deftimes.Days;
                   int diffInFeeding = Feedtimes.Days;

                   if (DiffDeficationInDays > reptile.DeficationLong)
                   {
                       HealthStatus += 2;
                       if (diffInFeeding > 5)
                       {
                           deficationMessage = ReptileType.NickName + " has not passed soilds in " + DiffDeficationInDays + " days, this is a seriours condition for " + ReptileType.ScientificName + ". Although the reptile has not feed in the past " + diffInFeeding + " days this could explain the issue.Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />  <a href=" + UriLeoDeficationHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriLeoDeficationHelp_002 + " " + target + ">Defication Help</a> <br />  <a href=" + UriLeoDeficationHelp_003 + " " + target + ">General Information</a>";
                           report.Add(deficationMessage);
                       }
                       else
                       {
                           deficationMessage = ReptileType.NickName + " has not passed soilds in " + DiffDeficationInDays + " days, this is a seriours condition for " + ReptileType.ScientificName + "Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />  <a href=" + UriLeoDeficationHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriLeoDeficationHelp_002 + " " + target + ">Defication Help</a> <br />  <a href=" + UriLeoDeficationHelp_003 + " " + target + ">General Information</a>";
                           report.Add(deficationMessage);
                       }

                   }
                   else if (DiffDeficationInDays > reptile.DeficationShort & DiffDeficationInDays < reptile.DeficationMedium)
                   {
                       HealthStatus += 1;
                       deficationMessage = ReptileType.NickName + " has not passed solids in " + DiffDeficationInDays + " days.This is not to serious but if this does not change consider bringing the reptile to the vet. Helpful links <br />  <a href=" + UriLeoDeficationHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriLeoDeficationHelp_002 + " " + target + ">Defication Help</a> <br />  <a href=" + UriLeoDeficationHelp_003 + " " + target + ">General Information</a>";
                       report.Add(deficationMessage);
                   }


                   //length check
                   // 1-2 months
                   String lengthIssue;

                   // System.Diagnostics.Debug.WriteLine(latestLength.Lengths +ReptileType.ReptileId+ "Hello-----------feeding date"); // test to check order of list
                   if (age > 30 & age <= 60)
                   {
                       System.Diagnostics.Debug.WriteLine(latestLength.Lengths + "   " + ReptileType.ReptileId  + "Hello-----------length value"); // test to check order of list
                       if (latestLength.Lengths <= reptile.LengthBaby)
                       {

                           HealthStatus += 2;
                           lengthIssue = ReptileType.CommonName + " is below the average size for its' age, please follow these links on caring for young " + ReptileType.ScientificName + ". Helpful links " + "<br />  <a href=" + UriBabyLeoHelp_001 + " " + target + ">baby Help</a> <br />  <a href=" + UriBabyLeoHelp_002 + " " + target + ">General Information</a>";
                           report.Add(lengthIssue);
                       }
                   }
                   // 3-6 months
                   else if (age > 61 & age < 182)
                   {
                       System.Diagnostics.Debug.WriteLine(latestLength.Lengths + "   " + ReptileType.ReptileId + "Hello-----------length value"); // test to check order of list
                       if (latestLength.Lengths <= reptile.LengthJuv)
                       {
                           HealthStatus += 2;
                           lengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.ScientificName + ". Helpful links" + "<br />  <a href=" + UriJuvenileLeoHelp_001 + " " + target + ">Juvenile Help</a> <br />  <a href=" + UriJuvenileLeoHelp_002 + " " + target + ">General Information</a>";
                           report.Add(lengthIssue);
                       }
                   }
                   // greater than 6 months
                   else if (age > 182)
                   {
                       if (latestLength.Lengths <= reptile.LengthAdult)
                       {
                           HealthStatus += 2;
                           lengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.ScientificName + ".<br /> Helpful links" + "<br />  <a href=" + UriJuvenileLeoHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriJuvenileLeoHelp_002 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoHelp_001 + " " + target + ">Leopard Gecko Health</a>";
                           report.Add(lengthIssue);
                       }
                   }
               }
                //green
                if (HealthStatus == 0)
                {
                    colour = "#7EBF7E";
                } //Unmellow Yellow
                else if (HealthStatus >= 1 && HealthStatus <= 2)
                {
                    colour = "#FFFF66";
                }//orange yellow
                else if (HealthStatus >= 3  && HealthStatus <= 4)
                {
                    colour = "#FFCC00";
                } //orange
                else if (HealthStatus >= 5 && HealthStatus <= 6)
                {
                    colour = "#FF9900";
                }// red
                else if (HealthStatus >= 7 && HealthStatus <= 8)
                {
                    colour = "#FF0000";
                } // black
                else if (HealthStatus >= 9 && HealthStatus <= 10)
                {
                    colour = "#000000";
                }

                return Tuple.Create(colour, report);
            }
        }
    }
}