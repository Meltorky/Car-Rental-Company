using car_rental.Application.DTOs.Car;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace car_rental.Web.ViewModels.Cars
{
    public class CarFormViewModel
    {   
        public CarFormDTO CarFormDTO { get; set; } = new();

        public IEnumerable<SelectListItem> CarTransmissionList { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> CarFuelList { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> BodyTypeList { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> FeatureList { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> BrandList { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
