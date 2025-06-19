using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Car;

namespace car_rental.Application.DTOs.Bookings
{
    public class BookingFormDTO
    {
        public int CarId { get; set; }
        public double PricePerDay { get; set; }

        [Required, Display(Name = "Pick Up Date")]
        public DateOnly BookingStartDate { get; set; }


        [Required, Display(Name = "Drop Off Date")]
        public DateOnly BookingEndDate { get; set; }


        [Required, Display(Name = "Pick Up Address")]
        public string Address { get; set; } = string.Empty;

        public double TotalCost
        {
            get
            {
                if (PricePerDay <= 0)
                {
                    return 0;
                }

                int numberOfDays = Math.Abs(BookingEndDate.DayNumber - BookingStartDate.DayNumber) + 1; // Or just (BookingEndDate - BookingStartDate).Days
                return numberOfDays * PricePerDay;
            }
        }

        public string UserId { get; set; } = string.Empty;
    }
}
