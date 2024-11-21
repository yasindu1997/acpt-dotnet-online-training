using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Van", Price = 89000, Qty = 5 },
                    new Product { Id = 2, Name = "Van", Price = 89000, Qty = 5 },
                    new Product { Id = 3, Name = "Van", Price = 89000, Qty = 5 }
                );
        }
    }
}