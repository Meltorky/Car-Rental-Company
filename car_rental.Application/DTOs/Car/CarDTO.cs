using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Entities;
using car_rental.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace car_rental.Application.DTOs.Car
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CarImage { get; set; } = string.Empty;
        public double PricePerDay { get; set; }

        [Range(1950, 2025, ErrorMessage = "Please enter a valid year between 1950 and 2025.")] // Adjust the range as needed
        public int Year { get; set; }

        public CarTransmission carTransmission { get; set; }  // enum
        public CarFuel carFuel { get; set; }  // enum
        public CarBodyType carBodyType { get; set; }  // enum
        public bool IsExist { get; set; } = true;
        public string Brand { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new List<string>();
    }
}
