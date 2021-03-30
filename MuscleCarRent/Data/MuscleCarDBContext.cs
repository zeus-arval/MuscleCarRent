using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Models;

namespace MuscleCarRent.Data
{
    public class MuscleCarDBContext : DbContext
    {
        public MuscleCarDBContext (DbContextOptions<MuscleCarDBContext> options)
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
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This method changes entities's names from plural to single form
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccessType>().ToTable("AccessType").HasKey(x => x.ID);
            modelBuilder.Entity<Account>().ToTable("Account").HasKey(x => x.ID);
            /*modelBuilder.Entity<Account>().HasOne(o => o.AccessType)
                .WithMany(o => o.Accounts);
            modelBuilder.Entity<Account>().HasMany(o => o.Orders)
                .WithOne(o => o.Account)
                .HasForeignKey(k => k.AccountID)
                .HasPrincipalKey(k => k.ID);*/
            modelBuilder.Entity<BankCard>().ToTable("BankCard").HasKey(x => x.ID);
            modelBuilder.Entity<Car>().ToTable("Car").HasKey(x => x.ID);
            modelBuilder.Entity<CarType>().ToTable("CarType").HasKey(x => x.ID);
            modelBuilder.Entity<Driver>().ToTable("Driver").HasKey(x => x.ID);
            modelBuilder.Entity<Image>().ToTable("Image").HasKey(x => x.ID);
            modelBuilder.Entity<Order>().ToTable("Order").HasKey(x => x.ID);
            modelBuilder.Entity<Promotion>().ToTable("Promotion").HasKey(x => x.ID);
        }
    }
}
