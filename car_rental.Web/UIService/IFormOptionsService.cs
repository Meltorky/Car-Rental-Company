using Microsoft.AspNetCore.Mvc.Rendering;

namespace car_rental.Web.UIService
{
    public interface IFormOptionsService
    {
        Task<IEnumerable<SelectListItem>> GetBrandSelectList();
        Task<IEnumerable<SelectListItem>> GetFeatureSelectList();
    }
}
