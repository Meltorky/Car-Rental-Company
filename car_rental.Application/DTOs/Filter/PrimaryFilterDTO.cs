using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.Application.DTOs.Filter
{
    public class PrimaryFilterDTO
    {
        // primary required filter

        [Required, Display(Name = "Pick Up Date")]
        public DateOnly StartDate { get; set; }

        [Required, Display(Name = "Drop Off Date")]
        public DateOnly EndDate { get; set; }

        [Required, Display(Name = "Pick Up Address")]
        public string Address { get; set; } = string.Empty;
    }
}
