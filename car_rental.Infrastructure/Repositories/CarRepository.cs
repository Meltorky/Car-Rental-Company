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
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllWithNoTracking()
        {
            return await _context.Set<Car>()
                .OrderByDescending(x => x.PricePerDay)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
