using System.Net;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Bookings;
using car_rental.Application.DTOs.Car;
using car_rental.Application.DTOs.Deal;
using car_rental.Application.DTOs.Filter;
using car_rental.Web.UIService;
using car_rental.Web.ViewModels.Deals;
using Humanizer;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace car_rental.Web.Controllers
{
    public class DealsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IFeatureService _featureService;
        private readonly IBookingService _bookingService;
        public DealsController(ICarService carService, IBrandService brandService, IFeatureService featureService, IFormOptionsService formOptionsService, IBookingService bookingService)
        {
            _carService = carService;
            _brandService = brandService;
            _featureService = featureService;
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Filter(PrimaryFilterDTO dto)
        {
            FilterDealsFormDTO filterForm = new()
            {
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Address = dto.Address
            };

            var vm = new DealsViewModel
            {
                BrandList = await _brandService.GetAll(),
                FeatureList = await _featureService.GetAll(),
                FilterDealsFormDTO = filterForm,
                CarList = await _carService.FilterCars(filterForm),
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter(DealsViewModel vm)
        {
            if (!ModelState.IsValid || !CheckDates(vm.FilterDealsFormDTO.StartDate, vm.FilterDealsFormDTO.EndDate))
            {
                vm.BrandList = await _brandService.GetAll();
                vm.FeatureList = await _featureService.GetAll();
                vm.CarList = await _carService.FilterCars(vm.FilterDealsFormDTO);
                return View(vm);
            }

            vm.BrandList = await _brandService.GetAll();
            vm.FeatureList = await _featureService.GetAll();
            vm.CarList = await _carService.FilterCars(vm.FilterDealsFormDTO);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking(DealsViewModel vm)
        {
            var carDTO = await _carService.GetByIdCarDTO(vm.BookingViewModel.CarDTO.Id);
            return View(new DealsViewModel
            {
                BookingViewModel = new()
                {
                    CarDTO = carDTO ?? new(),
                    BookingFormDTO = new()
                    {
                        Address = vm.BookingViewModel.BookingFormDTO.Address,
                        BookingStartDate = vm.BookingViewModel.BookingFormDTO.BookingStartDate,
                        BookingEndDate = vm.BookingViewModel.BookingFormDTO.BookingEndDate,
                        CarId = carDTO!.Id,
                        PricePerDay = carDTO!.PricePerDay,                     
                    }
                }
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBooking(DealsViewModel vm)
        {
            bool isValidDate = CheckDates(vm.BookingViewModel.BookingFormDTO.BookingStartDate,vm.BookingViewModel.BookingFormDTO.BookingEndDate);

            if (!isValidDate)
            {
                vm.BookingViewModel.CarDTO = await _carService.GetByIdCarDTO(vm.BookingViewModel.BookingFormDTO.CarId)?? new();
                return View(vm);
            }
            var result = await _bookingService.AddBooking(vm.BookingViewModel.BookingFormDTO);
            return View(nameof(Index),nameof(HomeController));
        }

        private bool CheckDates(DateOnly startDate,DateOnly endDate) 
        {
            return startDate <= endDate;
        }

    }
}
