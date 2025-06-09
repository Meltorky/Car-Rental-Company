using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs;
using car_rental.Application.DTOs.Feature;
using car_rental.Domain.Entities;

namespace car_rental.Application.Interfaces.IServices
{
    public interface IFeatureService
    {
        Task<FeatureDTO?> GetById(int id);
        Task<List<FeatureDTO>> GetAll();
        Task Add(FeatureDTO dTO);
        Task<bool> Remove(int id);
        Task<bool> Edit(FeatureDTO DTO);
    }
}
