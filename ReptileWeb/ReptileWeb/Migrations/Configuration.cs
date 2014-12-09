namespace ReptileWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ReptileWeb.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using QRCoder;
    internal sealed class Configuration : DbMigrationsConfiguration<ReptileWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
        }
     //    http://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-deploy-aspnet-mvc-app-membership-oauth-sql-database/
             bool AddUserAndRole(ReptileWeb.Models.ApplicationDbContext context)
                {
                    //for premuim members only allow them to access certain functions 
                    IdentityResult ir;
                    var rp = new RoleManager<IdentityRole>
                        (new RoleStore<IdentityRole>(context));
                    ir = rp.Create(new IdentityRole("canEdit"));
                    var um = new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(context));
                    var user = new ApplicationUser()
                    {
                        UserName = "stephenkenny@outlook.ie",
                    };
                    ir = um.Create(user, "03Dec93@");
                    if (ir.Succeeded == false)
                        return ir.Succeeded;
                    ir = um.AddToRole(user.Id, "canEdit");
                    return ir.Succeeded;
                 }
        protected override void Seed(ReptileWeb.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context); // for catagories permissions 

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
           // QRCodeGenerator qrGenerator = new QRCodeGenerator();
           
               context.Reptiles.AddOrUpdate(r => r.Id,
                  new Reptile { 
                      Id = "1",Gender = Gender.Male,SpeciesName = "Serpentes", 
                                ScientificName = "Python regius ",CommonName = "Royal Python",
                                Born ="03/12/2008",Morph = "Spider",Venomous = false,
                                Weight = 15,WeightProgress=WeightProgress.PlusWeight,Origin = "Africa",Food = "Rat",FeedingType = FeedingType.RatFrozen,AdultSize=27,Habitat="Tub" 
                  },
                  new Reptile
                  {
                      Id = "2",
                      
                      Gender = Gender.Female,
                      SpeciesName = "Serpentes",
                      ScientificName = "Python regius ",
                      CommonName = "Royal Python",
                      Born = "09/10/2007",
                      Morph = "Normal",
                      Venomous = false,
                      Weight = 15,
                      WeightProgress = WeightProgress.PlusWeight,
                      Origin = "Africa",
                      Food = "Rat",
                      FeedingType = FeedingType.RatFrozen,
                      AdultSize = 27,
                      Habitat = "Tub" 
                  },
                  new Reptile
                  {
                      Id = "3",
                      
                      Gender = Gender.Male,
                      SpeciesName = "Lacertilia",
                      ScientificName = "Eublepharis macularius",
                      CommonName = "Leopard Gecko",
                      Born = "25/5/2006",
                      Morph = "Hypo",
                      Venomous = false,
                      Weight = 15,
                      WeightProgress = WeightProgress.PlusWeight,
                      Origin = "Africa",
                      Food = "Rat",
                      FeedingType = FeedingType.RatFrozen,
                      AdultSize = 27,
                      Habitat = "Tub" 
                  }
                );
            
        }


        public bool True { get; set; }
    }
}
