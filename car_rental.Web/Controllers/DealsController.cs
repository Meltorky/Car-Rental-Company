﻿using System.Net;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Car;
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

        [HttpGet]
        public async Task<IActionResult> Booking(int id, string address, DateOnly startdate, DateOnly enddate)
        {
            var carDTO = await _carService.GetByIdCarDTO(id);
            return View(new BookingViewModel 
            {
                CarDTO = carDTO ?? new(),
                BookingFormDTO = new() 
                {
                    Address = address,
                    BookingStartDate = startdate,
                    BookingEndDate = enddate,
                    CarId = id,
                    PricePerDay = carDTO!.PricePerDay,                 
                }
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking(BookingViewModel vm)
        {
            var startDateStr = Request.Form["BookingFormDTO.BookingStartDate"];
            var endDateStr = Request.Form["BookingFormDTO.BookingEndDate"];
            DateOnly.TryParse(startDateStr, out var startDate);
            DateOnly.TryParse(endDateStr, out var endDate);

            if (!ModelState.IsValid || startDate > endDate) 
            {
                vm.CarDTO = await _carService.GetByIdCarDTO(vm.BookingFormDTO.CarId)?? new();
                return View(vm);
            }

            return View(vm);
        }

    }
}
