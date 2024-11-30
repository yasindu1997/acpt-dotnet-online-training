using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Data;
using EcommerceApi.dto;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController
    {
        private ProductContext productContext;

        public CategoryController(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        [HttpPost]
        public async Task<CategoryWithProductDto> SaveCategoryWithProduct(CategoryWithProductDto dto)
        {
            Category category = new Category
            {
                Name = dto.Name,
                Products = dto.Products.Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    Qty = p.Qty
                }).ToList()
            };

            productContext.Add(category);
            await productContext.SaveChangesAsync();

            return dto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryWithProducts(){
            List<Category> categories = await productContext.Categories.Include(c=>c.Products).ToListAsync();
            return categories;
        }
    }
}