using System.ComponentModel.DataAnnotations;
using car_rental.Application.DTOs.Bookings;
using car_rental.Application.DTOs.Car;
using car_rental.Domain.Entities;

namespace car_rental.Web.ViewModels.Deals
{
    public class BookingViewModel
    {
        public CarDTO CarDTO { get; set; } = new();
        public BookingFormDTO BookingFormDTO { get; set; } = new();

    }
}
