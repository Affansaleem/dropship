using dropship.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dropship.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products{get; set;}
        public DbSet<Category> Categories{get; set;}
        public DbSet<ProductCategory> ProductCategories{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite keys
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            // Product category can have a single product in product table but peoduct table can have multiple occurence in ProductCategory table
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(fk => fk.ProductId);
            // same as product category and product relation
            modelBuilder.Entity<ProductCategory>()
                .HasOne(c => c.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(fk => fk.CategoryId);
        }

    }
}
// dotnet ef migrations add "first"
// dotnet ef database update