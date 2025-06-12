using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Entities;

namespace car_rental.Application.Interfaces.IRepositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        new Task<Car?> GetById(int Id);
    }
}
