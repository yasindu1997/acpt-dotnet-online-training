using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
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

        //get, put, delete

    }
}