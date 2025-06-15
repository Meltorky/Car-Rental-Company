using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Booking;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Application.Interfaces.IServices;
using car_rental.Application.Mappers;

namespace car_rental.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> AddBooking(BookingFormDTO dto)
        {
            if (dto == null) return false;
            return await _bookingRepository.Add(dto.ToBookingEntity());
        }
    }
}
