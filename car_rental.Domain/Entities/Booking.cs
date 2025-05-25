using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Identity.Models;

namespace car_rental.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        // properties

        public DateOnly BookingStartDate { get; set; }
        public int BookingDays { get; set; }
        public DateOnly BookingEndDate => BookingStartDate.AddDays(BookingDays);
        public double TotalCost { get; set; }


        // forgien keys
        public string UserId { get; set; } = string.Empty;
        public int CarId { get; set; }


        // navigation properties
        public ApplicationUser User { get; set; } = default!;
        public Car Car { get; set; } = default!;

    }
}
