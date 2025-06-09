using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs;
using car_rental.Application.DTOs.Feature;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Application.Interfaces.IServices;
using car_rental.Application.Mappers;
using car_rental.Domain.Entities;

namespace car_rental.Application.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task Add(FeatureDTO dTO)
        {
            await _featureRepository.Add(new Feature 
            {
                Id = dTO.Id,
                Name = dTO.Name
            });
        }

        public async Task<bool> Edit(FeatureDTO dto)
        {
            if (dto is null)
                return false;

            return await _featureRepository.Update(new Feature 
            {
                Id = dto.Id,
                Name = dto.Name
            });
        }

        public async Task<List<FeatureDTO>> GetAll()
        {
            var result = await _featureRepository.GetAll();
            return result.ToFeatureDTOList();
        }

        public async Task<FeatureDTO?> GetById(int id)
        {
            var result = await _featureRepository.GetById(id);

            if (result == null)
                return null;

            return result.ToFeatureDTO();
        }

        public async Task<bool> Remove(int id)
        {
            var feature = await _featureRepository.GetById(id);

            if (feature is null)
                return false;

            return await _featureRepository.Delete(feature);
        }
    }
}
