using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Car;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Application.Interfaces.IServices;
using car_rental.Application.Mappers;
using Microsoft.AspNetCore.Http;

namespace car_rental.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarDTO>> GetAll()
        {
            var result = await _carRepository.GetAll();
            return result.ToCarDTOList();
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsNoTracking()
        {
            var result = await _carRepository.GetAllWithNoTracking();
            return result.ToCarDTOList();
        }

        public Task<CarDTO> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Add(CarFormDTO dTO)
        {
            if (dTO is null || dTO.CarImage is null)
                return false;

            var newCar = dTO.ToCarEntity(await HandleCarImageFile(dTO.CarImage));
            return await _carRepository.Add(newCar);
        }


        public Task<bool?> Edit(CarFormDTO dTO)
        {
            throw new NotImplementedException();

        }


        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> HandleCarImageFile(IFormFile carFile)
        {
            using var dataStream = new MemoryStream();
            await carFile.CopyToAsync(dataStream);
            return dataStream.ToArray();
        }

    }
}
