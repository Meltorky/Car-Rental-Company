using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Brand;
using car_rental.Application.DTOs.Feature;

namespace car_rental.Application.Interfaces.IServices
{
    public interface IBrandService
    {
        Task<BrandDTO?> GetById(int id);
        Task<List<BrandDTO>> GetAll();
    }
}
