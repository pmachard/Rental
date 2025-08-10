using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int IdCar { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int NbrDay { get; set; }
        public float Price { get; set; }
    }
}