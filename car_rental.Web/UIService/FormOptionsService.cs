using Microsoft.AspNetCore.Mvc.Rendering;

namespace car_rental.Web.UIService
{
    public class FormOptionsService : IFormOptionsService
    {
        private readonly IBrandService _brandService;
        private readonly IFeatureService _featureService;
        public FormOptionsService(IBrandService brandService, IFeatureService featureService)
        {
            _brandService = brandService;
            _featureService = featureService;
        }

        public async Task<IEnumerable<SelectListItem>> GetFeatureSelectList()
        {
            var features = await _featureService.GetAll();
            return features.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandSelectList()
        {
            var brands = await _brandService.GetAll();
            return brands.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });
        }
    }
}
