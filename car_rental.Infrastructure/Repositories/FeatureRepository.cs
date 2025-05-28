using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Domain.Entities;
using car_rental.Infrastructure.Data;

namespace car_rental.Infrastructure.Repositories
{
    public class FeatureRepository : BaseRepository<Feature> , IFeatureRepository
    {
        private readonly ApplicationDbContext _context;
        public FeatureRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
