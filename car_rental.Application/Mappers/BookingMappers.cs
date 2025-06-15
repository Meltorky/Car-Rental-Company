using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Booking;
using car_rental.Domain.Entities;

namespace car_rental.Application.Mappers
{
    public static class BookingMappers
    {
        public static Booking ToBookingEntity(this BookingFormDTO dto) 
        {
            return new Booking 
            {
                CarId = dto.CarId,
                Address = dto.Address,
                BookingStartDate = dto.BookingStartDate,
                BookingEndDate = dto.BookingEndDate,
                TotalCost = dto.TotalCost,
                UserId = dto.UserId,             
            };
        }
    }
}
