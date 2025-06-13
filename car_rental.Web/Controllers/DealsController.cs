using System.Threading.Tasks;
using car_rental.Application.DTOs.Deal;
using car_rental.Web.UIService;
using car_rental.Web.ViewModels.Deals;
using Microsoft.AspNetCore.Mvc;

namespace car_rental.Web.Controllers
{
    public class DealsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IFeatureService _featureService;
        public DealsController(ICarService carService, IBrandService brandService, IFeatureService featureService, IFormOptionsService formOptionsService)
        {
            _carService = carService;
            _brandService = brandService;
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> Filter()
        {
            var vm = new DealsViewModel
            {
                BrandList = await _brandService.GetAll(),
                FeatureList = await _featureService.GetAll(),
                CarList = await _carService.GetAll()
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter(DealsViewModel vm)
        {
            vm.BrandList = await _brandService.GetAll();
            vm.FeatureList = await _featureService.GetAll();
            vm.CarList = await _carService.FilterCars(vm.FilterDealsFormDTO);

            return View(vm);
        }
    }
}
