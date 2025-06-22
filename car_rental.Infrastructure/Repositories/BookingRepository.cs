using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Domain.Entities;
using car_rental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace car_rental.Infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking> , IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetByUserIdAsync(string id)
        {
            return await _context.Set<Booking>()
                .Where(x => x.UserId == id)
                .AsNoTracking()
                .OrderByDescending(x => x.BookingEndDate)
                .Include(b => b.Car)
                .ThenInclude(c => c.Brand)
                .ToListAsync();
        }
    }
}
