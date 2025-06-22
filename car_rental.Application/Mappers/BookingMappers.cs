using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Bookings;
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

        public static List<BookingDTO> ToBookingDTOList(this List<Booking> list) 
        {
            var dtoList = new List<BookingDTO>();

            foreach (var item in list) 
            {
                dtoList.Add(new BookingDTO 
                {
                    Address = item.Address,
                    BookingStartDate = item.BookingStartDate,
                    BookingEndDate = item.BookingEndDate,
                    TotalCost = item.TotalCost,
                    UserId = item.UserId,
                    BookingId = item.BookingId,
                    CarBrand = item.Car.Brand.Name,
                    CarName = item.Car.Name,
                    CarImage = Convert.ToBase64String(item.Car.CarImage)
                });
            }

            return dtoList;
        }
    }
}
