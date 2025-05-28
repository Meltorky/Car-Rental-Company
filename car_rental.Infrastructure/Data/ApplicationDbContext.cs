using car_rental.Domain.Entities;
using car_rental.Domain.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace car_rental.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Booking> Bookings { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<CarFeature> CarFeatures { get; set; }
        DbSet<Feature> Features { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarFeature>()
                .HasKey(e => new { e.CarId, e.FeatureId });



            // seeding Data
            modelBuilder.Entity<Feature>().HasData(new List<Feature>
            {
                new Feature { Id = 1 , Name = "Heated Seats" },
                new Feature { Id = 2 , Name = "Leather Interior" },
                new Feature { Id = 3 , Name = "Panoramic Roof" },
                new Feature { Id = 4 , Name = "Off-Road" },
                new Feature { Id = 5 , Name = "Family" },
                new Feature { Id = 6, Name = "Business" },
                new Feature { Id = 7, Name = "Luxury" },
                new Feature { Id = 8, Name = "Exotic"},
                new Feature { Id = 9, Name = "V12" },
                new Feature { Id = 10, Name = "Sport" },

            });


            // Customize Special Schema for Identity Tables

            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
        }
    }
}
