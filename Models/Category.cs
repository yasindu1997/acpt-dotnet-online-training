using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //relationship define
        public ICollection<Product> Products { get; set; }
    }
}