using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //to seed data
            // modelBuilder.Entity<Product>()
            //     .HasData(
            //         new Product { Id = 1, Name = "Van", Price = 89000, Qty = 5 },
            //         new Product { Id = 2, Name = "Van", Price = 89000, Qty = 5 },
            //         new Product { Id = 3, Name = "Van", Price = 89000, Qty = 5 }
            //     );

            // Configure the one-to-many relationship using Fluent API
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete
        }
    }
}