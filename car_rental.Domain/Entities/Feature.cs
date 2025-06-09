using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.Domain.Entities
{
    public class Feature : BaseEntity<Feature>
    {
        // navigation properties 

        public ICollection<CarFeature> carFeatures { get; set; } = new List<CarFeature>();
    }
}
