using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Brand;
using car_rental.Application.DTOs.Feature;
using car_rental.Domain.Enums;

namespace car_rental.Application.DTOs.Deal
{
    public class FilterDealsFormDTO
    {
        // primary required filter
        
        [Required, Display(Name = "Pick Up Date")]
        public DateOnly StartDate { get; set; }

        [Required, Display(Name = "Drop Off Date")]
        public DateOnly EndDate { get; set; }

        [Required, Display(Name = "Pick Up Address")]
        public string Address { get; set; } = string.Empty;


        // secondry optional filter
        public double? MaxPrice { get; set; }
        public int? BrandId { get; set; }
        public List<int>? FeatureIds { get; set; }
        public CarBodyType? CarBodyType { get; set; }
        public CarFuel? CarFuel { get; set; }
        public CarTransmission? CarTransmission { get; set; }
    }
}
