using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Entities_DTOs
{
    public class Product : BaseDTO
    {
        public string Name { get; set; }
        public string Category { get; set; } 
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


    }
}
