using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.Domain.Entities
{
    public class Brand : BaseEntity<Brand>
    {
        public string ImageUrl { get; set; } = string.Empty;

        // navigation properties
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
