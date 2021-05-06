using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Data
{
    public class MuscleCarRentDBContext : DbContext
    {
        public MuscleCarRentDBContext (DbContextOptions<MuscleCarRentDBContext> options)
            : base(options)
        {
        }
        
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
            modelBuilder.Entity<AccessTypeData>().ToTable("AccessType");
            modelBuilder.Entity<AccountData>().ToTable("Account");
            modelBuilder.Entity<BankCardData>()
                .HasOne(a => a.Account)
                .WithOne(b => b.BankCard)
                .HasForeignKey<AccountData>(a => a.BankCardID);
            modelBuilder.Entity<BankCardData>().ToTable("BankCard");
            modelBuilder.Entity<CarData>().ToTable("Car");
            modelBuilder.Entity<CarTypeData>().ToTable("CarType");
            modelBuilder.Entity<DriverData>().ToTable("Driver");
            modelBuilder.Entity<ImageData>().ToTable("Image");
            modelBuilder.Entity<OrderData>().ToTable("Order");
            modelBuilder.Entity<PromotionData>().ToTable("Promotion");
        }
    }
}
