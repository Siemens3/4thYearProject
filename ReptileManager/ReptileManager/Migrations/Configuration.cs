namespace ReptileManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ReptileManager.Models;
    // http://www.asp.net/mvc/overview/security/create-an-aspnet-mvc-5-web-app-with-email-confirmation-and-password-reset link for add password reset
    internal sealed class Configuration : DbMigrationsConfiguration<ReptileManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
      /*  bool AddUserAndRole(ReptileManager.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        } */
        protected override void Seed(ReptileManager.Models.ApplicationDbContext context)
        {
            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        //    AddUserAndRole(context);
            context.Reptiles.AddOrUpdate(r => r.ReptileId,
                 new Reptile
                 {
                     ReptileId = "1",
                     QRCode = null,
                     Gender = Gender.Male,
                     SpeciesName = "Serpentes",
                     ScientificName = "Python regius ",
                     CommonName = "Royal Python",
                     Born = new DateTime(2012, 3, 20),
                     Morph = "Spider",
                     Venomous = false,
                     
                     Weight = 15,
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
                     TimeStamp = new DateTime(2015,3,27),
                     DueDate =  new DateTime(2015,3,25),
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
                     ScientificName = "Python regius ",
                     CommonName = "Royal Python",
                     Born = new DateTime(2015, 1, 27),
                     Morph = "Normal",
                     Venomous = false ,
                      Weight = 15,
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
                     TimeStamp = new DateTime(2015, 3, 17),
                     DueDate = new DateTime(2015, 3, 14),
                      TubeBoxNumber = "4",
                      Note = "Paws is doing well.",
                      SalesCardComment = "beautiful snake, well tempered." 
                 },
                 new Reptile
                 {
                     ReptileId = "3",
                     QRCode = null,
                     Gender = Gender.Male,
                     SpeciesName = "Lacertilia",
                     ScientificName = "Eublepharis macularius",
                     CommonName = "Leopard Gecko",
                     Born = new DateTime(2014,11,27),
                     Morph = "Hypo",
                     Venomous = false ,
                      Weight = 15,
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
                      TimeStamp = new DateTime(2015, 3, 15),
                      DueDate = new DateTime(2015, 3, 10),
                      TubeBoxNumber = "7",
                      Note="Give peanut a smaller amount of food.",
                      SalesCardComment ="none"
                      
                 }
               );

        }
    }
}
