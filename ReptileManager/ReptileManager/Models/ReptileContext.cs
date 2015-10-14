using System.Data.Entity;
using System.Diagnostics;

namespace ReptileManager.Models
{
    public class ReptileContext : DbContext
    {
        public ReptileContext()
            : base("DefaultConnection")
        {
           
        }

     

        public DbSet<Reptile> Reptiles { get; set; }

        public DbSet<Mating> Matings { get; set; }

        public  DbSet<Notification> Notifications { get; set; }

        public  DbSet<Other> Other { get; set; }

        public  DbSet<Medication> Medications { get; set; }

        public  DbSet<Shed> Sheds { get; set; }

        public  DbSet<Defication> Defications { get; set; }

        public  DbSet<Cleaning> Cleanings { get; set; }

        public  DbSet<Feeding> Feedings { get; set; }

        public  DbSet<BreedingCycle> BreedingCycles { get; set; }

        public  DbSet<Ultrasound> Ultrasounds { get; set; }

        public  DbSet<Note> Notes { get; set; }

        public  DbSet<Weight> Weights { get; set; }

        public  DbSet<Length> Lengths { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Images> Images { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Reptile>()
        //        .HasMany(x => x.Images)
        //        .WithRequired().WillCascadeOnDelete(true);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}