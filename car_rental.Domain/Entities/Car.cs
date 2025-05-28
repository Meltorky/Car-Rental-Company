using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Enums;

namespace car_rental.Domain.Entities
{
    public class Car : BaseEntity
    {
        public byte[] CarImage { get; set; } = Array.Empty<byte>();
        public double PricePerDay { get; set; }
        public int Year { get; set; }
        public CarTransmission carTransmission { get; set; }
        public CarFuel carFuel { get; set; }
        public CarBodyType carBodyType { get; set; }
        public bool IsExist { get; set; } = true;


        // Forgien keys

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = default!;


        // Navigation properties
        public ICollection<CarFeature> CarFeatures { get; set; } = default!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
