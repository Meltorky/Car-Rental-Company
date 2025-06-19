using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Bookings;

namespace car_rental.Application.Interfaces.IServices
{
    public interface IBookingService
    {
        Task<bool> AddBooking(BookingFormDTO dto);
    }
}
