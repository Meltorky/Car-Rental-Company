﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Entities;

namespace car_rental.Application.Interfaces.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<List<Booking>> GetByUserIdAsync(string id);
    }
}
