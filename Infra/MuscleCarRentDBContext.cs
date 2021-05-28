using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Data;

namespace MuscleCarRentProject.Infra
{
    public class MuscleCarRentDBContext : IdentityDbContext
    {
        public MuscleCarRentDBContext() 
            : this(new DbContextOptionsBuilder<MuscleCarRentDBContext>().Options) { }

        public MuscleCarRentDBContext(DbContextOptions<MuscleCarRentDBContext> options)
            : base(options) { }
        
        public DbSet<AccessTypeData> AccessTypes { get; set; }
        public DbSet<AccountData> Accounts { get; set; }
        public DbSet<BankCardData> BankCards { get; set; }
        public DbSet<CarData> Cars{ get; set; }
        public DbSet<CarTypeData> CarTypes { get; set; }
        public DbSet<DriverData> Drivers { get; set; }
        public DbSet<ImageData> Images { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderedDateData> OrderedDates { get; set; }
        public DbSet<PromotionData> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccessTypeData>().ToTable("AccessTypes");
            modelBuilder.Entity<AccountData>().ToTable("Accounts");
            modelBuilder.Entity<BankCardData>().ToTable("BankCards");
            modelBuilder.Entity<CarData>().ToTable("Cars");
            modelBuilder.Entity<CarTypeData>().ToTable("CarTypes");
            modelBuilder.Entity<DriverData>().ToTable("Drivers");
            modelBuilder.Entity<ImageData>().ToTable("Images");
            modelBuilder.Entity<OrderData>().ToTable("Orders");
            modelBuilder.Entity<PromotionData>().ToTable("Promotions");
        }
    }
}
