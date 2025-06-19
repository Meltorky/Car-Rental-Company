using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Car;
using car_rental.Domain.Entities;
using car_rental.Domain.Enums;

namespace car_rental.Application.Mappers
{
    public static class CarMappers
    {
        public static IEnumerable<CarDTO> ToCarDTOList(this List<Car> cars)
        {
            var carDTOs = new List<CarDTO>();
            foreach (var car in cars)
            {
                carDTOs.Add(new CarDTO
                {
                    Id = car.Id,
                    Name = car.Name,
                    Year = car.Year,
                    PricePerDay = car.PricePerDay,
                    IsExist = car.IsExist,
                    Brand = car.Brand.Name,
                    carTransmission = car.carTransmission,
                    carFuel = car.carFuel,
                    carBodyType = car.carBodyType,
                    Features = car.CarFeatures.Select(cf => cf.Feature.Name).ToList(),
                    CarImage = Convert.ToBase64String(car.CarImage)
                });
            }
            return carDTOs;
        }


        public static CarDTO ToCarDTO(this Car car)
        {
            return new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
                IsExist = car.IsExist,
                Brand = car.Brand.Name,
                carTransmission = car.carTransmission,
                carFuel = car.carFuel,
                carBodyType = car.carBodyType,
                Features = car.CarFeatures.Select(cf => cf.Feature.Name).ToList(),
                CarImage = Convert.ToBase64String(car.CarImage),
                Bookings = car.Bookings.ToList()
            };
        }



        public static CarFormDTO ToCarFormDTO(this Car car) 
        {
            return new CarFormDTO
            {
                Id = car.Id,
                Name = car.Name,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
                BrandId = car.Brand.Id,
                CarTransmission = car.carTransmission,
                CarFuel = car.carFuel,
                CarBodyType = car.carBodyType,
                FeatureIds = car.CarFeatures.Select(cf => cf.Feature.Id).ToList(),
                ExistingImagePath = Convert.ToBase64String(car.CarImage)
            };
        }


        public static Car ToCarEntity(this CarFormDTO dto, byte[] carImage)
        {
            return new Car()
            {
                Id = dto.Id,
                Name = dto.Name,
                BrandId = dto.BrandId,
                carBodyType = dto.CarBodyType,
                carFuel = dto.CarFuel,
                carTransmission = dto.CarTransmission,
                PricePerDay = dto.PricePerDay,
                Year = dto.Year,
                CarImage = carImage,
                CarFeatures = dto.FeatureIds.Select(e => new CarFeature { CarId = dto.Id, FeatureId = e }).ToList(),
            };
        }

        public static Car ToCarEntityForEdit(this CarFormDTO dto, Car car)
        {
            car.Id = dto.Id;
            car.Name = dto.Name;
            car.BrandId = dto.BrandId;
            car.carBodyType = dto.CarBodyType;
            car.carFuel = dto.CarFuel;
            car.carTransmission = dto.CarTransmission;
            car.PricePerDay = dto.PricePerDay;
            car.Year = dto.Year;
            //car.CarImage = carImage ?? car.CarImage;
            car.CarFeatures = dto.FeatureIds.Select(e => new CarFeature { CarId = dto.Id, FeatureId = e }).ToList();
            return car;
        }
    }
}
