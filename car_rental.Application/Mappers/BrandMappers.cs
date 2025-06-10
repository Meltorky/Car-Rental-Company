using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Brand;
using car_rental.Domain.Entities;

namespace car_rental.Application.Mappers
{
    public static class BrandMappers
    {
        public static List<BrandDTO> ToBrandDTOList(this List<Brand> brands)
        {
            var dtoList = new List<BrandDTO>();
            foreach (var brand in brands)
            {
                dtoList.Add(new BrandDTO 
                { 
                    Id = brand.Id,
                    Name = brand.Name,
                    ImageURL = brand.ImageUrl
                });
            }
            return dtoList;
        }

        public static BrandDTO ToBrandDTO(this Brand brand) => new BrandDTO
        {
            Id = brand.Id,
            Name = brand.Name,
            ImageURL = brand.ImageUrl
        };
    }
}
