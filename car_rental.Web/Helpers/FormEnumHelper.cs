using Microsoft.AspNetCore.Mvc.Rendering;

namespace car_rental.Web.Helpers
{
    public static class FormEnumHelper
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new SelectListItem
                {
                    Value = Convert.ToInt32(e).ToString(),
                    Text = e.ToString()
                });
        }
    }
}
