using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductContext context;

        public ProductController(ProductContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> SaveProduct(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();

            return product;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return Ok(new {message = "Deleted !"});
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product){
            //check a data, a row is exists by this id
            //then update
        }

    }
}