using car_rental.Application.DTOs.Brand;
using car_rental.Web.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc;

namespace car_rental.Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new BrandViewModel
            {
                BrandList = await _brandService.GetAll()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                viewModel.BrandList = await _brandService.GetAll();
                return View(nameof(Index),viewModel);
            }

            await _brandService.Add(viewModel.BrandFormDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandViewModel viewModel) 
        {
            var updatedBrand = await _brandService.Edit(viewModel.BrandFormDTO);

            if (!ModelState.IsValid || updatedBrand is null || updatedBrand is false) 
            {
                viewModel.BrandList = await _brandService.GetAll();
                return View(nameof(Index), viewModel);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id) 
        {
            var result = await _brandService.Remove(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
