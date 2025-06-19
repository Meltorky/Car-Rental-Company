using System.Diagnostics;
using car_rental.Application.DTOs.Deal;
using car_rental.Application.DTOs.Filter;
using car_rental.Web.Models;
using car_rental.Web.ViewModels.Deals;
using Microsoft.AspNetCore.Mvc;

namespace car_rental.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        [HttpPost]
        public IActionResult FindDeals(PrimaryFilterDTO dto) 
        {
            if (!ModelState.IsValid || dto.StartDate > dto.EndDate)
                return View();

            return RedirectToAction("Filter","Deals",dto);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
