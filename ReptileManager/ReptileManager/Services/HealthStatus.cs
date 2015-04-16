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
                String weightLossMessage;
                var LastFiveWeights = WeightList.Take(5);

                System.Diagnostics.Debug.WriteLine(LastFiveWeights.FirstOrDefault().Weights + "Hello-------------------1");
                
                DateTime born = ReptileType.Born.Value;
                DateTime newDate = DateTime.UtcNow;

                TimeSpan tsAge = newDate - born;
                int age = tsAge.Days;
                

                for (int i = 0; i < LastFiveWeights.Count(); i++)
                {
                    if (age <= 30)
                    {
                        break;
                    }
                    else
                    {
                        // 1-2 months
                        if (age > 30 & age < 60)
                        {
                            if (LastFiveWeights.FirstOrDefault().Weights < 2)
                            {
                                HealthStatus += 2;
                                weightLossMessage = ReptileType.CommonName + " has not gained much weight, please follow these links on caring for young " + ReptileType.SpeciesName + ". " + "<br />" + UriBabyLeoHelp_001 + "<br />" + UriBabyLeoHelp_002;
                                report.Add(weightLossMessage);
                                break;
                            }
                        }
                        // 3-6 months
                        else if (age > 90 & age < 182)
                        {
                            if (WeightList.FirstOrDefault().Weights < 5)
                            {
                                HealthStatus += 2;
                                weightLossMessage = ReptileType.NickName + " has not gained much weight, this is serious because of the age " + ReptileType.Born + " please follow these links on caring for young " + ReptileType.SpeciesName + ". " + "<br />" + UriJuvenileLeoHelp_001 + "<br />" + UriJuvenileLeoHelp_002;
                                report.Add(weightLossMessage);
                                break;
                            }
                        }
                        // greater than 6 months
                        else if (age > 182)
                        {
                            if (LastFiveWeights.ElementAt(i).Weights > LastFiveWeights.First().Weights)
                            {
                                WeightLoss = LastFiveWeights.Last().Weights - LastFiveWeights.First().Weights;

                                System.Diagnostics.Debug.WriteLine(LastFiveWeights.Last().Weights+"Hello-----------"); // test to check order of list

                                if (WeightLoss >= DangerWeightLoss)
                                {
                                    DangerWeight = true;
                                    HealthStatus += 2;
                                    weightLossMessage = "ID:" + id + " has lost " + WeightLoss + "grams. This is very seriours. Helpful links:" + UriLeoHelp_001.ToString();
                                    report.Add(weightLossMessage);
                                }
                                else if (WeightLoss < MinorWeightLoss)
                                {
                                    MinorWeight = true;
                                    HealthStatus += 1;
                                    weightLossMessage = "ID:" + id + " has lost " + WeightLoss + "grams. This reptile requires attention. Helpful links:" + UriLeoHelp_001.ToString();
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

                        if (differenceInDays < 14)
                        {
                            if (DangerWeight == true)
                            {
                                HealthStatus += 2;
                                justGaveBirth = "This reptile just gave birth in the last two week. This would explain the weight loss of " + WeightLoss + ". This is a serious amount of weight loss. Please reconsider breeding this reptile. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                report.Add(justGaveBirth);
                            }
                            else if (MinorWeight == true)
                            {
                                HealthStatus += 1;
                                justGaveBirth = "This reptile just gave birth in the last two week. This would explain the weight loss of " + WeightLoss + ". This is a minor amount of weight loss. This would be normal. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                report.Add(justGaveBirth);
                            }
                        }
                        else if (differenceInDays > 14 & differenceInDays < 28)
                        {
                            if (DangerWeight == true)
                            {
                                HealthStatus += 2;
                                justGaveBirth = "This reptile recently gave birth in the last month. This would explain the weight loss of " + WeightLoss + ". This is a serious amount of weight loss. This would not be normal. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
                                report.Add(justGaveBirth);
                            }
                            else if (MinorWeight == true)
                            {
                                HealthStatus += 1;
                                justGaveBirth = "This reptile recently gave birth in the last month. This would explain the weight loss of " + WeightLoss + ". This is a minor amount of weight loss. This would be normal. Consider seperating this reptile or a bigger diet to help gain weight. Please read these links on caring for" + ReptileType.SpeciesName + ".<br /> " + UriLeoBreedingHelp_001 + "<br />" + UriLeoBreedingHelp_002;
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
                    TimeSpan ts = shedDate - newDate;
                    int diffInDays = ts.Days;

                    if (diffInDays > 7)
                    {
                        HealthStatus += 2;
                        shedWarning = ReptileType.NickName + " is in " + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is not normal. Please read these links to help solve this issue." + "<br />" + UriLeoSheddingHelp_001 + "<br />" + UriLeoSheddingHelp_002 + "<br />" + UriLeoSheddingHelp_003 + "<br />" + UriLeoSheddingHelp_004;
                        report.Add(shedWarning);
                    }
                    else if (diffInDays > 4 & diffInDays < 6)
                    {
                        HealthStatus += 1;
                        shedWarning = ReptileType.NickName + "is in" + latestShed.Sheds.ToString() + " for the past " + diffInDays + " days. This is ok. Please read these links if this issue continues. " + "<br />" + UriLeoSheddingHelp_001 + "<br />" + UriLeoSheddingHelp_002 + "<br />" + UriLeoSheddingHelp_003 + "<br />" + UriLeoSheddingHelp_004;
                        report.Add(shedWarning);
                    }
                }

                //defication check
                String deficationMessage;
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
                        deficationMessage = ReptileType.NickName + " Has not passed soilds in " + DiffDefInDays + " days, this is a seriours condition for" + ReptileType.ScientificName + ". Althought the reptile has not feed in the past " + diffInFeeding + "days this could explain the issue.Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                        report.Add(deficationMessage);
                    }
                    else
                    {
                        deficationMessage = ReptileType.NickName + " Has not passed soilds in " + DiffDefInDays + " days, this is a seriours condition for" + ReptileType.ScientificName + "Consider bringing the reptile to the vet for checks.<br /> Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                        report.Add(deficationMessage);
                    }

                }
                else if (DiffDefInDays > 2 & DiffDefInDays < 5)
                {
                    HealthStatus += 1;
                    deficationMessage = ReptileType.NickName + " has not passed solids in " + DiffDefInDays + " days.This is not to serious but if this does not change consider bringing the reptile to the vet. Helpful links <br />" + UriLeoDeficationHelp_001 + "<br />" + UriLeoDeficationHelp_002 + "<br />" + UriLeoDeficationHelp_003;
                    report.Add(deficationMessage);
                }

                //length check
                // 1-2 months
                String lengthIssue;
                if (age > 30 & age < 60)
                {
                    if (latestLength.Lengths < 3)
                    {

                        HealthStatus += 2;
                        lengthIssue = ReptileType.CommonName + " is below the average size for its' age, please follow these links on caring for young " + ReptileType.SpeciesName + ". Helpful links " + UriBabyLeoHelp_001 + "<br />" + UriBabyLeoHelp_002;
                        report.Add(lengthIssue);
                    }
                }
                // 3-6 months
                else if (age > 90 & age < 182)
                {
                    if (latestLength.Lengths < 4)
                    {
                        HealthStatus += 2;
                        lengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.SpeciesName + ". Helpful links" + "<br />" + UriJuvenileLeoHelp_001 + "<br />" + UriJuvenileLeoHelp_002;
                        report.Add(lengthIssue);
                    }
                }
                // greater than 6 months
                else if (age > 182)
                {
                    if (latestLength.Lengths < 7)
                    {
                        HealthStatus += 2;
                        lengthIssue = ReptileType.NickName + " is below the average size for its' age,  please follow these links on caring for young " + ReptileType.SpeciesName + ".<br /> Helpful links" + "<br />  <a href=" + UriJuvenileLeoHelp_001 + " " + target + ">General Help</a> <br />  <a href=" + UriJuvenileLeoHelp_002 + " " + target + ">General Information</a> <br /> <a href=" + UriLeoHelp_001 + " " + target + ">Leopard Gecko Health</a>";
                        report.Add(lengthIssue);
                    }
                }


                if (HealthStatus == 0)
                {
                    colour = "#7EBF7E";
                }
                else if (HealthStatus >= 1 || HealthStatus <= 2)
                {
                    colour = "#FFFF66";
                }
                else if (HealthStatus <= 4)
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

                return Tuple.Create(colour, report);
            }
        }
    }


}