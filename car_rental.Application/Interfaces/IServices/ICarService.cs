using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Car;

namespace car_rental.Application.Interfaces.IServices
{
    public interface ICarService
    {
        Task<CarDTO> GetById(int Id);
        Task<IEnumerable<CarDTO>> GetAll();
        Task<IEnumerable<CarDTO>> GetAllAsNoTracking();
        Task<bool> Add(CarFormDTO dTO);
        Task<bool?> Edit(CarFormDTO dTO);
        Task<bool> Remove(int id);

    }
}
