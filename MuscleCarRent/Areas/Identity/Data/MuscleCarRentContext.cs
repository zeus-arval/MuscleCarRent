using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Models;

namespace MuscleCarRent.Data
{
    public class MuscleCarRentContext : IdentityDbContext<IdentityUser>
    {
        public MuscleCarRentContext(DbContextOptions<MuscleCarRentContext> options)
            : base(options)
        {
        }

        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PersonalPromotion> PersonalPromotions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This method changes entities's names from plural to single form
            modelBuilder.Entity<AccessType>().ToTable("AccessType");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<BankCard>().ToTable("BankCard");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<CarType>().ToTable("CarType");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<PersonalPromotion>().ToTable("PersonalPromotion");
            modelBuilder.Entity<Promotion>().ToTable("Promotion");

        }
    }
}
