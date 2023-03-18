using CarsConsulting.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsConsulting.DAL
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Maker> Makers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(_ =>
            {
                _.HasKey(car => car.Id);

                _.HasOne(car => car.Maker)                
                .WithMany(maker => maker.Cars)
                .HasForeignKey(car => car.Id);

                _.Property(car => car.CylinderNumber)
                .HasConversion<string>()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Maker>(_ =>
            {
                _.HasKey(maker => maker.Id);

                _.HasMany(maker => maker.Cars)
                .WithOne(car => car.Maker)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
