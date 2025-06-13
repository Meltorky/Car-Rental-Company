using System.ComponentModel.DataAnnotations;
using car_rental.Application.DTOs.Brand;
using car_rental.Application.DTOs.Car;
using car_rental.Application.DTOs.Deal;
using car_rental.Application.DTOs.Feature;
using car_rental.Domain.Enums;

namespace car_rental.Web.ViewModels.Deals
{
    public class DealsViewModel
    {
        // the primary filter of Date and Location
        public FilterDealsFormDTO FilterDealsFormDTO { get; set; } = new();

        // filterd Cars
        public IEnumerable<CarDTO> CarList { get; set; } = new List<CarDTO>();

        // the Lists that used for secondary filter 
        public IEnumerable<BrandDTO> BrandList { get; set; } = new List<BrandDTO>();
        public IEnumerable<FeatureDTO> FeatureList { get; set; } = new List<FeatureDTO>();

        public IEnumerable<CarBodyType> CarBodyTypeList { get; } = Enum.GetValues(typeof(CarBodyType)).Cast<CarBodyType>();
        public IEnumerable<CarFuel> CarFuelList { get;} = Enum.GetValues(typeof(CarFuel)).Cast<CarFuel>();
        public IEnumerable<CarTransmission> CarTransmissionList { get; } = Enum.GetValues(typeof(CarTransmission)).Cast<CarTransmission>();

    }
}
