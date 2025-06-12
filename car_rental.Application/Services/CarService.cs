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
using Microsoft.EntityFrameworkCore;

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
            var result = await _carRepository.GetAll(
                c => c.Include(b => b.Brand),
                c => c.Include(cf => cf.CarFeatures).ThenInclude(f => f.Feature)
            );
            return result.ToCarDTOList();
        }


        public async Task<CarFormDTO?> GetById(int Id)
        {
            var car = await _carRepository.GetById(Id);
            if (car is null) return null;
            return car.ToCarFormDTO();
        }


        public async Task<bool> Add(CarFormDTO dTO)
        {
            if (dTO is null || dTO.CarImage is null)
                return false;

            var newCar = dTO.ToCarEntity(await HandleCarImageFile(dTO.CarImage));
            return await _carRepository.Add(newCar);
        }


        public async Task<bool?> Edit(CarFormDTO dto)
        {
            var car = await _carRepository.GetById(dto.Id);

            if (car == null)
                return null;

            if (dto.CarImage is not null)
                car.CarImage = await HandleCarImageFile(dto.CarImage);

            var result = dto.ToCarEntityForEdit(car);
            return await _carRepository.Update(result);
        }


        public async Task<bool> Remove(int id)
        {
            var car = await _carRepository.GetById(id);
            if (car is null) return false;
            return await _carRepository.Delete(car);
        }


        public async Task<byte[]> HandleCarImageFile(IFormFile carFile)
        {
            using var dataStream = new MemoryStream();
            await carFile.CopyToAsync(dataStream);
            return dataStream.ToArray();
        }

    }
}
