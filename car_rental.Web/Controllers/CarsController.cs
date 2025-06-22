using car_rental.Application.DTOs.Car;
using car_rental.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using car_rental.Web.ViewModels.Cars;
using car_rental.Web.Helpers;
using car_rental.Web.UIService;
using Microsoft.AspNetCore.Authorization;


namespace car_rental.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IFeatureService _featureService;
        private readonly IFormOptionsService _formOptionsService;
        public CarsController(ICarService carService, IBrandService brandService, IFeatureService featureService, IFormOptionsService formOptionsService)
        {
            _carService = carService;
            _brandService = brandService;
            _featureService = featureService;
            _formOptionsService = formOptionsService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _carService.GetAll());
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = await GetSelectedListsInCarFormVM();
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var result = await GetSelectedListsInCarFormVM(vm.CarFormDTO);
                return View(result);
            }

            bool IsAdded = await _carService.Add(vm.CarFormDTO);
            return IsAdded ?
                RedirectToAction(nameof(Index)) :
                View(await GetSelectedListsInCarFormVM(vm.CarFormDTO));
        }


        [HttpGet("cars/edit/{Id}")]
        public async Task<IActionResult> Edit(int Id)
        {
            var viewModel = await GetSelectedListsInCarFormVM();
            viewModel.CarFormDTO = await _carService.GetById(Id)?? new CarFormDTO();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CarFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var result = await GetSelectedListsInCarFormVM(vm.CarFormDTO);
                return View(result);
            }

            var isUpdated = await _carService.Edit(vm.CarFormDTO);

            if (isUpdated is false || isUpdated is null)
                View(await GetSelectedListsInCarFormVM(vm.CarFormDTO));

            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id) 
        {
            await _carService.Remove(Id);
            return RedirectToAction(nameof(Index));
        }


        private async Task<CarFormViewModel> GetSelectedListsInCarFormVM(CarFormDTO? carFormDTO = null)
        {
            return new CarFormViewModel
            {
                CarTransmissionList = FormEnumHelper.GetEnumSelectList<CarTransmission>(),
                CarFuelList = FormEnumHelper.GetEnumSelectList<CarFuel>(),
                BodyTypeList = FormEnumHelper.GetEnumSelectList<CarBodyType>(),
                FeatureList = await _formOptionsService.GetFeatureSelectList(),
                BrandList = await _formOptionsService.GetBrandSelectList(),
                CarFormDTO = carFormDTO ?? new()
            };
        }

    }
}
