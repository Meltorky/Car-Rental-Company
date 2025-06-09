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

        public async Task<IActionResult> Index()
        {
            return View(await _brandService.GetAll());
        }
    }
}
