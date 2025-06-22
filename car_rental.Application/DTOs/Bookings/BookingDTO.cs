using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Entities;
using car_rental.Domain.Identity.Models;

namespace car_rental.Application.DTOs.Bookings
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public DateOnly BookingStartDate { get; set; }
        public DateOnly BookingEndDate { get; set; }
        public double TotalCost { get; set; }
        public string Address { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string CarBrand { get; set; } = string.Empty;
        public string CarName { get; set; } = string.Empty;
        public string CarImage { get; set; } = string.Empty;
    }
}
