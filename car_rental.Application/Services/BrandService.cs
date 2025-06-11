using car_rental.Application.DTOs.Brand;
using car_rental.Application.Settings;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Application.Interfaces.IServices;
using car_rental.Application.Mappers;
using car_rental.Domain.Entities;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


namespace car_rental.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly string _storagePath;
        private readonly string _wwwrootHost;

        public BrandService(IBrandRepository brandRepository, string wwwrootHost)
        {
            _brandRepository = brandRepository;
            _wwwrootHost = wwwrootHost;
            _storagePath = Path.Combine(_wwwrootHost, BrandLogoFileSettings.StoragePathOnServer);
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

        public async Task<bool> Add(BrandFormDTO dto)
        {
            return await _brandRepository.Add(new Brand
            {
                Id = dto.Id,
                Name = dto.Name,
                ImageUrl = await SaveBrandLogo(dto.LogoFile)
            });
        }

        public async Task<bool?> Edit(BrandFormDTO dto)
        {
            var brand = await _brandRepository.GetById(dto.Id);

            if (brand is null)
                return null;

            brand.Name = dto.Name;

            if (dto.LogoFile is not null) 
            {
                File.Delete(Path.Combine(_storagePath, brand.ImageUrl));
                brand.ImageUrl = await SaveBrandLogo(dto.LogoFile);
            }

            return await _brandRepository.Update(brand);
        }

        public async Task<bool> Remove(int Id)
        {
            var brand = await _brandRepository.GetById(Id);

            if (brand is null)
                return false;

            bool result = await _brandRepository.Delete(brand);

            if (result is true)
                File.Delete(Path.Combine(_storagePath,brand.ImageUrl));

            return result;
        }

        private async Task<string> SaveBrandLogo(IFormFile? file) 
        {
            if (file is null)
                return string.Empty;

            var logoName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(_storagePath,logoName);

            using var stream = File.Create(fullPath);
            await file.CopyToAsync(stream);

            return logoName;
        }
    }
}
