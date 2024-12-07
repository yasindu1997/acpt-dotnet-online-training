using EcommerceApi.dto;
using EcommerceApi.Models;
using EcommerceApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EcommerceApi.service
{
    public class ProductService
    {

        private ProductContext context;

        public ProductService(ProductContext context)
        {
            this.context = context;
        }

        public async Task<ProductDto> SaveProduct(ProductDto product)
        {
            Product prod = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty
            };

            context.Add(prod);
            await context.SaveChangesAsync();
            return new ProductDto
            {
                Id = prod.Id,
                Name = prod.Name,
                Price = prod.Price,
                Qty = prod.Qty
            };
        }

        public void DeleteProduct(int id)
        {

        }

        public void UpdateProduct(Product product, int id)
        {

        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
                List<ProductDto> productDtos = await context.Products.Select(p=>new ProductDto{
                Id=p.Id,
                Name=p.Name,
                Price=p.Price,
                Qty = p.Qty
               }).ToListAsync();

            // await context.Products.Where(p=>p.Price>3000).ToListAsync();

            // await context.Products.FromSqlRaw("SELECT * FROM Prodcuts where Price > @price AND Qty = @qty",
            //  new SqlParameter("@price", 3000), new SqlParameter("@qty", 5)).ToListAsync();

            return productDtos;
        }
    }
}