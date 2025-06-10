using car_rental.Application.DTOs.Feature;

namespace car_rental.Web.ViewModels.Features
{
    public class FeatureViewModel
    {
        public IEnumerable<FeatureDTO> Features { get; set; } = new List<FeatureDTO>();
        public FeatureDTO FormModel { get; set; } = new FeatureDTO();
    }
}
