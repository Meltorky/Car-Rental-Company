using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Brand;
using car_rental.Application.DTOs.Feature;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Application.Interfaces.IServices;
using car_rental.Application.Mappers;

namespace car_rental.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<BrandDTO>> GetAll()
        {
            var result = await _brandRepository.GetAll();
            return result.ToBrandDTOList();
        }

        public async Task<BrandDTO?> GetById(int id)
        {
            var result = await _brandRepository.GetById(id);

            if (result == null)
                return null;

            return result.ToBrandDTO();
        }
    }
}
