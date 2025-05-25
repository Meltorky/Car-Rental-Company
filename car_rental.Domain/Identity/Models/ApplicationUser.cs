using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace car_rental.Domain.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
