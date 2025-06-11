using car_rental.Application.DTOs.Car;
using car_rental.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using car_rental.Web.ViewModels.Cars;


namespace car_rental.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IFeatureService _featureService;
        public CarsController(ICarService carService, IBrandService brandService, IFeatureService featureService)
        {
            _carService = carService;
            _brandService = brandService;
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(await _carService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = await GetSelectedListsInCarFormVM();
            return View(viewModel);
        }

        private async Task<CarFormViewModel> GetSelectedListsInCarFormVM() 
        {
            var features = await _featureService.GetAll();
            var featureList = features.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });

            var brands = await _brandService.GetAll();
            var brandList = brands.Select(b => new SelectListItem 
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });

            return new CarFormViewModel
            {
                CarTransmissionList = Enum.GetValues<CarTransmission>()
                       .Select(ct => new SelectListItem
                       {
                           Value = ((int)ct).ToString(),
                           Text = ct.ToString()
                       }),
                CarFuelList = Enum.GetValues<CarFuel>()
                       .Select(cf => new SelectListItem
                       {
                           Value = ((int)cf).ToString(),
                           Text = cf.ToString()
                       }),
                BodyTypeList = Enum.GetValues<CarBodyType>()
                       .Select(bt => new SelectListItem
                       {
                           Value = ((int)bt).ToString(),
                           Text = bt.ToString()
                       }),
                FeatureList = featureList,
                BrandList = brandList,
            };
        }

    }
}
