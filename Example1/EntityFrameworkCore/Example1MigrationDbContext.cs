using Example1.Models;
using Microsoft.EntityFrameworkCore;

namespace Example1.EntityFrameworkCore
{
    public class Example1MigrationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        public Example1MigrationDbContext(
            DbContextOptions<Example1MigrationDbContext> options
        ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(b =>
            {
                b.ToTable("Products");

                b.Property(x => x.Name).IsRequired().HasMaxLength(100);
                b.Property(x => x.Description).HasMaxLength(500);

                b.HasKey(x => new { x.Name, x.Price });
            });

            modelBuilder.Entity<SaleItem>(b =>
            {
                b.ToTable("SaleItems");

                b.Property(x => x.SaleName).IsRequired().HasMaxLength(100);
                b.Property(x => x.StartDate).HasColumnType("date");
                b.Property(x => x.EndDate).HasColumnType("date");

                b.HasKey(x => new { x.SaleName, x.Price });
            });
        }
    }
}
