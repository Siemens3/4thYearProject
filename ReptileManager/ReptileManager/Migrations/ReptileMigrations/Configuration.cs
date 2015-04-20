namespace ReptileManager.Migrations.ReptileMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ReptileManager.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<ReptileManager.Models.ReptileContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ReptileMigrations";
            ContextKey = "ReptileManager.Models.ReptileContext";
            
        }

        protected override void Seed(ReptileManager.Models.ReptileContext context)
        {
            var reptiles = new List<Reptile>
               {
                    new Reptile
                     {
                         ReptileId = "1",
                         QRCode = null,
                         Gender = Gender.Male,
                         SpeciesName = "Serpentes",
                         ScientificName = "Python regius",
                         CommonName = "Royal Python",
                         Born =  DateTime.Parse("2010, 3, 20"),
                         Morph = "Spider",
                         Venomous = false,
                         Weight = 2500,
                         WeightProgress=WeightProgress.PlusWeight,Origin = "Africa",
                         Food = "Rat",
                         FeedingType = FeedingType.RatFrozen,
                         AdultSize=27,
                         Habitat="Tub",
                         Breeder = "Mick Duff",
                         BreederEmail = "",
                         Cities = "Dublin",
                         ClutchID = "12A",
                         ForSale = true,
                         Price = "€120.00",
                         NickName = "Bee",
                         LicenseNumber = "1234",
                         ChipNumber = "Ab2",
                         SpeciesNumber = "6",
                         FatherNotInDb = null,
                         MotherNotInDb =null,
                         FeedInterval = 1,
                         TimeStamp = DateTime.Parse("2015-4-09 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 25"),
                         TubeBoxNumber = "2",
                         Note = "Bee is very aggressive",
                         SalesCardComment = "Snake is easy to care for but needs someone with some experience." 
                     },
                     new Reptile
                     {
                         ReptileId = "2",
                         QRCode = null,
                         Gender = Gender.Female,
                         SpeciesName = "Serpentes",
                         ScientificName = "Python regius",
                         CommonName = "Royal Python",
                         Born = DateTime.Parse("2015, 1, 27"),
                         Morph = "Normal",
                         Venomous = false ,
                          Weight = 175,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.RatFrozen,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Aoife Kirwan",
                          BreederEmail = "",
                          Cities = "Oslo",
                          ClutchID = "6",
                          ForSale = true,
                          Price = "€60.00",
                          NickName = "Paws",
                          LicenseNumber = "55667",
                          ChipNumber = "127",
                          SpeciesNumber = "8",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 7,
                         TimeStamp = DateTime.Parse("2015-4-08 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 14"),
                          TubeBoxNumber = "4",
                          Note = "Paws is doing well.",
                          SalesCardComment = "beautiful snake, well tempered." 
                     },
                     new Reptile
                     {
                         ReptileId = "3",
                         QRCode = null,
                         Gender = Gender.Female,
                           SpeciesName = "Serpentes",
                         ScientificName = "Python regius",
                        CommonName = "Royal Python",
                         Born = DateTime.Parse("2013, 11, 27"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 789,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.RatFrozen,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Damien Butler",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 1"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "4",
                         QRCode = null,
                         Gender = Gender.Female,
                           SpeciesName = "Serpentes",
                         ScientificName = "Python regius",
                         CommonName = "Royal Python",
                         Born = DateTime.Parse("2015, 3, 1"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 95,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.RatFrozen,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Mick Kenny",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 30"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "5",
                         QRCode = null,
                         Gender = Gender.Male,
                            SpeciesName = "Serpentes",
                         ScientificName = "Python regius",
                          CommonName = "Royal Python",
                         Born = DateTime.Parse("2015, 1, 5"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 200,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.RatFrozen,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Jacob Stone",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 10"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "6",
                         QRCode = null,
                         Gender = Gender.Male,
                         SpeciesName = "Lacertilia",
                         ScientificName = "Eublepharis macularius",
                         CommonName = "Leopard Gecko",
                         Born = DateTime.Parse("2015, 3, 25"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 65,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Pakistan",
                          Food = "mealworm",
                          FeedingType = FeedingType.Mealworms,
                          AdultSize = 7,
                          Habitat = "Tub",
                          Breeder = "Luke Kerns",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 10"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "7",
                         QRCode = null,
                         Gender = Gender.Male,
                         SpeciesName = "Lacertilia",
                         ScientificName = "Eublepharis macularius",
                         CommonName = "Leopard Gecko",
                         Born = DateTime.Parse("2015, 3, 1"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 20,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.Mealworms,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Linda carroll",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 4, 10"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "8",
                         QRCode = null,
                         Gender = Gender.Male,
                         SpeciesName = "Lacertilia",
                         ScientificName = "Eublepharis macularius",
                         CommonName = "Leopard Gecko",
                         Born = DateTime.Parse("2015, 1, 1"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 3,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.Mealworms,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "James smith",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 10"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "9",
                         QRCode = null,
                         Gender = Gender.Male,
                         SpeciesName = "Lacertilia",
                         ScientificName = "Eublepharis macularius",
                         CommonName = "Leopard Gecko",
                         Born = DateTime.Parse("2013, 12, 10"),
                         Morph = "Hypo",
                         Venomous = false ,
                          Weight = 55,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.Mealworms,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Mick Wall",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "peanut",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 10"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     },
                      new Reptile
                     {
                         ReptileId = "10",
                         QRCode = null,
                         Gender = Gender.Female,
                         SpeciesName = "Lacertilia",
                         ScientificName = "Eublepharis macularius",
                         CommonName = "Leopard Gecko",
                         Born = DateTime.Parse("2014, 11, 13"),
                         Morph = "normal",
                         Venomous = false ,
                          Weight = 55,
                          WeightProgress = WeightProgress.PlusWeight,
                          Origin = "Africa",
                          Food = "Rat",
                          FeedingType = FeedingType.Mealworms,
                          AdultSize = 27,
                          Habitat = "Tub",
                          Breeder = "Amy Burn",
                          BreederEmail = "",
                          Cities = "New York",
                          ClutchID = "3R",
                          ForSale = false,
                          Price = "€0.00",
                          NickName = "sugar",
                          LicenseNumber = "43211",
                          ChipNumber = "12P",
                          SpeciesNumber = "9",
                          FatherNotInDb = null,
                          MotherNotInDb = null,
                          FeedInterval = 3,
                         TimeStamp = DateTime.Parse("2015-4-10 10:00 AM"),
                         DueDate = DateTime.Parse("2015, 3, 10"),
                          TubeBoxNumber = "7",
                          Note="Give peanut a smaller amount of food.",
                          SalesCardComment ="none"
                      
                     }
               };

            reptiles.ForEach(x => context.Reptiles.AddOrUpdate(r=>r.ReptileId,x));
            context.SaveChanges();


            var length = new List<Length>
            {
                new Length{Lengths = 6, Date = DateTime.Parse("2015,1,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Length{Lengths = 12, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Length{Lengths = 14, Date = DateTime.Parse("2015,3,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Length{Lengths = 15, Date = DateTime.Parse("2015,4,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},

                   new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                    new Length{Lengths = 9,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                    new Length{Lengths = 12,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                    new Length{Lengths = 15,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},

                    new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                    new Length{Lengths = 5.5,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                    new Length{Lengths = 6,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                    new Length{Lengths = 6.5,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                     new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),

                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                    new Length{Lengths = 5.5,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                    new Length{Lengths = 6,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                    new Length{Lengths = 6.5,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},

                     new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                    new Length{Lengths = 5.5,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                    new Length{Lengths = 6,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                    new Length{Lengths = 6.5,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},

                     new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},
                    new Length{Lengths = 5.5,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},
                    new Length{Lengths = 6,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},
                    new Length{Lengths = 6.5,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},

                    
                    new Length{Lengths = 2,Date = DateTime.Parse("2015,4,1"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},

                    
                    new Length{Lengths = 3.8,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},

                     new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                    new Length{Lengths = 5.5,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                    new Length{Lengths = 6,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                    new Length{Lengths = 6.5,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},

                     new Length{Lengths = 5,Date = DateTime.Parse("2015,1,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                    new Length{Lengths = 5.5,Date = DateTime.Parse("2015,2,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                    new Length{Lengths = 6,Date = DateTime.Parse("2015,3,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                    new Length{Lengths = 7.5,Date = DateTime.Parse("2015,4,5"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
             };
            foreach (Length l in length)
            {
                var lengthInDateBase = context.Lengths.Where(
                    r => r.Reptile.ReptileId == l.ReptileId).FirstOrDefault();
                if (lengthInDateBase == null)
                {
                    context.Lengths.Add(l);
                }
            }
            context.SaveChanges();

            var feeding = new List<Feeding>
            {
                new Feeding{Date = DateTime.Parse("2015,1,10"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                     new Feeding{Date = DateTime.Parse("2015,2,10"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                     new Feeding{Date = DateTime.Parse("2015,3,10"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                     new Feeding{Date = DateTime.Parse("2015,4,10"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                   

                    new Feeding{Date = DateTime.Parse("2015,3,25"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                   
                    new Feeding{Date = DateTime.Parse("2015,3,25"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                   
                    new Feeding{Date = DateTime.Parse("2015,3,25"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                   
                    new Feeding{Date = DateTime.Parse("2015,3,25"),Feedings = FeedingType.RatFrozen,
                    FoodSize = FoodSize.S,NumItemsFed = 1,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                   
                    

                     new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},

                      new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},

                      new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},

                      new Feeding{Date = DateTime.Parse("2015,4,10"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.M,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},
                  

                      new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},

                      new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},

                      new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,18"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},

                      new Feeding{Date = DateTime.Parse("2015,1,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 5,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,2,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 7,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,3,2"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 9,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                   new Feeding{Date = DateTime.Parse("2015,4,19"),Feedings = FeedingType.Mealworms,
                    FoodSize = FoodSize.S,NumItemsFed = 12,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                  
             };
            foreach (Feeding f in feeding)
            {
                var feedInDateBase = context.Feedings.Where(
                    r => r.Reptile.ReptileId == f.ReptileId).FirstOrDefault();
                if (feedInDateBase == null)
                {
                    context.Feedings.Add(f);
                }
            }
            context.SaveChanges();

            var defication = new List<Defication>
            {
                new Defication{Date = DateTime.Parse("2015,3,10"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Defication{Date = DateTime.Parse("2015,3,31"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,3,31"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,3,31"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,3,31"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,4,10"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,4,18"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,4,18"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,3,31"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                     new Defication{Date = DateTime.Parse("2015,4,19"),Defications= "Normal",Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
             };
            foreach (Defication d in defication)
            {
                var defInDateBase = context.Defications.Where(
                    r => r.Reptile.ReptileId == d.ReptileId).FirstOrDefault();
                if (defInDateBase == null)
                {
                    context.Defications.Add(d);
                }
            }
            context.SaveChanges();

            var shedsList = new List<Shed>
            {
                new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Preshed,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Badshed,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Shedout,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Shedout,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Shedout,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Shedout,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,4,5"),Sheds = ShedType.Badshed,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,4,15"),Sheds = ShedType.Shedout,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Inshed,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                     new Shed{Date = DateTime.Parse("2015,3,31"),Sheds = ShedType.Shedout,Notes = "",
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
             };
            foreach (Shed s in shedsList)
            {
                var shedInDateBase = context.Sheds.Where(
                    r => r.Reptile.ReptileId == s.ReptileId).FirstOrDefault();
                if (shedInDateBase == null)
                {
                    context.Sheds.Add(s);
                }
            }
            context.SaveChanges();

            var weights = new List<Weight>
            {
                new Weight{Weights = 65, Date = DateTime.Parse("2015,1,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Weight{Weights = 50, Date = DateTime.Parse("2015,2,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Weight{Weights = 20, Date = DateTime.Parse("2015,3,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                    new Weight{Weights = 15, Date = DateTime.Parse("2015,4,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "1").ReptileId},
                  

                    new Weight{Weights = 25, Date = DateTime.Parse("2015,1,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                    new Weight{Weights = 35, Date = DateTime.Parse("2015,2,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                    new Weight{Weights = 45, Date = DateTime.Parse("2015,3,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                    new Weight{Weights = 55, Date = DateTime.Parse("2015,4,2"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "2").ReptileId},
                   

                    new Weight{Weights = 1200, Date = DateTime.Parse("2015,1,5"),
                    ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                     new Weight{Weights = 1150, Date = DateTime.Parse("2015,1,15"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                    new Weight{Weights = 1100, Date = DateTime.Parse("2015,1,25"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},
                    new Weight{Weights = 1000, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "3").ReptileId},

                     new Weight{Weights = 65, Date = DateTime.Parse("2015,1,5"),
                    ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                     new Weight{Weights = 70, Date = DateTime.Parse("2015,1,15"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                    new Weight{Weights = 80, Date = DateTime.Parse("2015,1,25"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},
                    new Weight{Weights = 95, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "4").ReptileId},

                     new Weight{Weights = 50, Date = DateTime.Parse("2015,1,5"),
                    ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                     new Weight{Weights = 55, Date = DateTime.Parse("2015,1,15"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                    new Weight{Weights = 48, Date = DateTime.Parse("2015,1,25"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},
                    new Weight{Weights = 70, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "5").ReptileId},

                    
                    new Weight{Weights = 1, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "6").ReptileId},

                     new Weight{Weights = 1, Date = DateTime.Parse("2015,4,12"),
                    ReptileId = reptiles.Single(r =>r.ReptileId == "7").ReptileId},
                    

                    
                    new Weight{Weights = 4, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "8").ReptileId},

                     new Weight{Weights = 50, Date = DateTime.Parse("2015,1,5"),
                    ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                     new Weight{Weights = 45, Date = DateTime.Parse("2015,1,15"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                    new Weight{Weights = 40, Date = DateTime.Parse("2015,1,25"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},
                    new Weight{Weights = 35, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "9").ReptileId},

                     new Weight{Weights = 50, Date = DateTime.Parse("2015,1,5"),
                    ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                     new Weight{Weights = 55, Date = DateTime.Parse("2015,1,15"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                    new Weight{Weights = 60, Date = DateTime.Parse("2015,1,25"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                    new Weight{Weights = 64, Date = DateTime.Parse("2015,2,10"),
                   ReptileId = reptiles.Single(r =>r.ReptileId == "10").ReptileId},
                 

            };
            foreach (Weight w in weights)
            {
                var weightInDateBase = context.Weights.Where(
                    r => r.Reptile.ReptileId == w.ReptileId).FirstOrDefault();
                if (weightInDateBase == null)
                {
                    context.Weights.Add(w);
                }
            }
            context.SaveChanges();
        }
    }
}
