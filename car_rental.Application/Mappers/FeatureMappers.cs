using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.DTOs.Feature;
using car_rental.Domain.Entities;

namespace car_rental.Application.Mappers
{
    public static class FeatureMappers
    {
        public static List<FeatureDTO> ToFeatureDTOList(this List<Feature> features)
        {
            var dtoList = new List<FeatureDTO>();

            foreach (var feature in features)
            {
                dtoList.Add(new FeatureDTO { Id = feature.Id, Name = feature.Name });
            }
            return dtoList;
        }

        public static FeatureDTO ToFeatureDTO(this Feature feature) => new FeatureDTO
        {
            Id = feature.Id,
            Name = feature.Name
        };
    }
}
