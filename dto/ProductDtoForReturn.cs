using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.dto
{
    public class ProductDtoForReturn
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}