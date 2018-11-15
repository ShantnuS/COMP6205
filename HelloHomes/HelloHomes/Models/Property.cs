using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Environment;

namespace HelloHomes.Models
{
    public class Property
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Hey - you've gotta give a name between 5 and 100 characters long!")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
