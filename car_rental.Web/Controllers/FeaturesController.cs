using car_rental.Application.DTOs.Feature;
using car_rental.Domain.Identity.Enums;
using car_rental.Web.ViewModels.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace car_rental.Web.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IFeatureService _featureService;
        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var features = await _featureService.GetAll();
            return View(new FeatureViewModel
            {
                Features = features,
                FormModel = new FeatureDTO()
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeatureViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(nameof(Index), viewModel); 
            }

            await _featureService.Add(viewModel.FormModel);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Authorize(Roles = nameof(ApplicationRoles.Admin))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FeatureViewModel viewModel)
        {
            var result = await _featureService.Edit(viewModel.FormModel);

            if (!ModelState.IsValid || result is false)
            {
                viewModel.Features = await _featureService.GetAll();
                return View(nameof(Index), viewModel);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Authorize(Roles = nameof(ApplicationRoles.Admin))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id) 
        {
            await _featureService.Remove(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
