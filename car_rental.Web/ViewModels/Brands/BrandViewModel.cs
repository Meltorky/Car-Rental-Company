using car_rental.Application.DTOs.Brand;

namespace car_rental.Web.ViewModels.Brands
{
    public class BrandViewModel
    {
        public IEnumerable<BrandDTO> BrandList { get; set; } = new List<BrandDTO>();
        public BrandFormDTO BrandFormDTO { get; set; } = new BrandFormDTO();
    }
}
