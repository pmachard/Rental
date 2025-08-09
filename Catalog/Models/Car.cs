using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Registration { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public decimal PricePerDay { get; set; }
    }
}