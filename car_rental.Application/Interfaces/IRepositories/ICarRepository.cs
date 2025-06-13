using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Deal;
using car_rental.Domain.Entities;

namespace car_rental.Application.Interfaces.IRepositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        new Task<Car?> GetById(int Id);
        Task<IEnumerable<Car>> GetFilteredCarwithAllCriteria(FilterDealsFormDTO dto);
        Task<IEnumerable<Car>> GetFilteredCarwithAnyCriteria(FilterDealsFormDTO dto);

    }
}
