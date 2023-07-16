using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class product
    {
        [Key]
        public int productId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
