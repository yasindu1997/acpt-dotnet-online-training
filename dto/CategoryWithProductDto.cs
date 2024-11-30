using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.dto
{
    public class CategoryWithProductDto
    {
        public string Name { get; set; }
        public List<ProductDtoForReturn> Products { get; set; }
    }
}