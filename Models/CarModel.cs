using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string ProductionCountry { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }

        [Range(1800, 2022)]
        [DataType(DataType.Date)]
        public int ProductionDate { get ; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
