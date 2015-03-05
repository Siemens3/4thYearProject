using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReptileManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ReptileManager.Models.Reptile> Reptiles { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Mating> Matings { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Other> Other { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Medication> Medications { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Shed> Sheds { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Defication> Defications { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Cleaning> Cleanings { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Feeding> Feedings { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.BreedingCycle> BreedingCycles { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Ultrasound> Ultrasounds { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Note> Notes { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Weight> Weights { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.Length> Lengths { get; set; }

        public System.Data.Entity.DbSet<ReptileManager.Models.File> Files { get; set; }
        

    }
}