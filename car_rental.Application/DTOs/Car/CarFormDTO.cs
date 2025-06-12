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
        public string? ExistingImagePath { get; set; } // use for edit
        public double PricePerDay { get; set; }
        public int Year { get; set; }
        public int BrandId { get; set; }
        public CarTransmission CarTransmission { get; set; }  // enum
        public CarFuel CarFuel { get; set; }  // enum
        public CarBodyType CarBodyType { get; set; }  //enum
        public List<int> FeatureIds { get; set; } = new List<int>();
    }
}
