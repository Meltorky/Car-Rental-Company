using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Domain.Entities;
using car_rental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace car_rental.Infrastructure.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Use the 'new' keyword to explicitly hide the inherited member
        public new async Task<Car?> GetById(int Id)
        {
            return await _context.Set<Car>()
                //.AsNoTracking()               // when i do it, the brandId and FeatureIds not updated
                .Include(b => b.Brand)
                .Include(cf => cf.CarFeatures)
                .ThenInclude(f => f.Feature)
                .FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}
