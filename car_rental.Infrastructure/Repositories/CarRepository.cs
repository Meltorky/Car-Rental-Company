using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Deal;
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
                .Include(b => b.Bookings)
                .Include(cf => cf.CarFeatures)
                .ThenInclude(f => f.Feature)
                .FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Car>> GetFilteredCarwithAllCriteria(FilterDealsFormDTO dto)
        {
            var query = _context.Set<Car>()
                .Where(car => car.Bookings.All(b =>
                    b.BookingEndDate < dto.StartDate || b.BookingStartDate > dto.EndDate))
                .AsNoTracking()
                .Include(c => c.Brand)
                .Include(c => c.CarFeatures)
                .ThenInclude(cf => cf.Feature)
                .AsQueryable();

            if (dto.MaxPrice.HasValue)
                query = query.Where(c => c.PricePerDay <= dto.MaxPrice.Value);

            if (dto.BrandId.HasValue)
                query = query.Where(c => c.BrandId == dto.BrandId.Value);

            if (dto.CarBodyType.HasValue)
                query = query.Where(c => c.carBodyType == dto.CarBodyType.Value);

            if (dto.CarFuel.HasValue)
                query = query.Where(c => c.carFuel == dto.CarFuel.Value);

            if (dto.CarTransmission.HasValue)
                query = query.Where(c => c.carTransmission == dto.CarTransmission.Value);

            if (dto.FeatureIds != null && dto.FeatureIds.Any())
                query = query.Where(c =>
                    dto.FeatureIds.All(fId =>
                        c.CarFeatures.Select(cf => cf.FeatureId).Contains(fId)
                    )
                );

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetFilteredCarwithAnyCriteria(FilterDealsFormDTO dto)
        {
            List<IQueryable<Car>> queriesToUnion = new List<IQueryable<Car>>();

            if (dto.MaxPrice.HasValue)
            {
                queriesToUnion.Add(_context.Set<Car>().Where(c => c.PricePerDay <= dto.MaxPrice));
            }

            if (dto.BrandId.HasValue)
            {
                queriesToUnion.Add(_context.Set<Car>().Where(c => c.BrandId == dto.BrandId));
            }

            if (dto.CarBodyType.HasValue)
            {
                queriesToUnion.Add(_context.Set<Car>().Where(c => c.carBodyType == dto.CarBodyType.Value));
            }

            if (dto.CarFuel.HasValue)
            {
                queriesToUnion.Add(_context.Set<Car>().Where(c => c.carFuel == dto.CarFuel.Value));
            }

            if (dto.CarTransmission.HasValue)
            {
                queriesToUnion.Add(_context.Set<Car>().Where(c => c.carTransmission == dto.CarTransmission.Value));
            }

            if (dto.FeatureIds != null && dto.FeatureIds.Any())
            {
                queriesToUnion.Add(_context.Set<Car>()
                    .Where(c => dto.FeatureIds
                    .All(fId => c.CarFeatures
                    .Select(cf => cf.FeatureId)
                    .Contains(fId))));
            }

            IQueryable<Car> unionedQuery = _context.Set<Car>()
                .Where(car => car.Bookings.All(b =>
                    b.BookingEndDate < dto.StartDate || b.BookingStartDate > dto.EndDate))
                .AsNoTracking()
                .Include(c => c.Brand)
                .Include(c => c.CarFeatures)
                .ThenInclude(cf => cf.Feature)
                .AsQueryable();

            foreach (var query in queriesToUnion)
            {
                unionedQuery.Union(query);
            }

            return await unionedQuery.ToListAsync();
        }

    }
}
