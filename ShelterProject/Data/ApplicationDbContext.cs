using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShelterProject.Models;

namespace ShelterProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Animal> Animals { get; set; }
        public DbSet<Models.Shelter> Shelters { get; set; }
        public DbSet<Models.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Models.Ownership> Ownerships { get; set; }
        public DbSet<Models.MedicalWriteoff> MedicalWriteoffs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.Ownership>().HasKey(x => new { x.Id, x.ShelterId, x.ApplicationUserId});
            builder.Entity<Models.Ownership>().HasOne(x => x.Shelter).WithMany(x => x.Owners).HasForeignKey(x => x.ShelterId);
            builder.Entity<Models.Ownership>().HasOne(x => x.ApplicationUser).WithMany(x => x.SheltersOwning).HasForeignKey(x => x.ApplicationUserId);

            builder.Entity<Models.Animal>().HasOne(x => x.MedicalWriteoff).WithOne(x => x.Animal).HasForeignKey<MedicalWriteoff>(x => x.AnimalId);
            builder.Entity<Models.MedicalWriteoff>().HasOne(x => x.Animal).WithOne(x => x.MedicalWriteoff).HasForeignKey<Animal>(x => x.MedicalWriteoffId);
        }
    }
}
