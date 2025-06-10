using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace car_rental.Application.DTOs.Brand
{
    public class BrandFormDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        public IFormFile? LogoFile { get; set; }
    }
}
