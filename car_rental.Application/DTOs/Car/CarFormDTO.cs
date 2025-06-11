using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Enums;
using car_rental.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_rental.Application.DTOs.Car
{
    public class CarFormDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IFormFile? CarImage { get; set; }
        public double PricePerDay { get; set; }
        public int Year { get; set; }
        public int BrandId { get; set; }
        public CarTransmission CarTransmission { get; set; }
        public CarFuel CarFuel { get; set; }
        public CarBodyType CarBodyType { get; set; }
        public List<int> FeatureIds { get; set; } = new List<int>();
    }
}
