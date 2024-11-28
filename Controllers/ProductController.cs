using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Data;
using EcommerceApi.dto;
using EcommerceApi.Models;
using EcommerceApi.service;
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

        private ProductService service;

        public ProductController(ProductService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> SaveProduct(ProductDto product)
        {
            ProductDto productDto = await service.SaveProduct(product);
            return Created("/api/Product/" + productDto.Id, productDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            IEnumerable<ProductDto> enumerable = await service.GetProducts();
            return Ok(enumerable);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            // var product = await context.Products.FindAsync(id);

            // if (product == null)
            // {
            //     return NotFound();
            // }

            // return product;
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            // Product product = await context.Products.FindAsync(id);

            // if (product == null)
            // {
            //     return NotFound();
            // }
            // else
            // {
            //     context.Products.Remove(product);
            //     await context.SaveChangesAsync();
            //     return Ok(new { message = "Deleted !" });
            // }

            return null;
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Product>> UpdateProduct(int id, Product product){
        //     check a data, a row is exists by this id
        //     then update
        // }

    }
}