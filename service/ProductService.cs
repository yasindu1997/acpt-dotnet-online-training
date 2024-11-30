using EcommerceApi.dto;
using EcommerceApi.Models;
using EcommerceApi.Data;
using Microsoft.EntityFrameworkCore;

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

           return productDtos;
        }
    }
}