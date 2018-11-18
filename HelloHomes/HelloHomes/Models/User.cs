using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public class User
    {

        public long Id { get; set; }

        //Is true if the user is an admin.
        public bool IsAdmin { get; set; }

        [Required]
        //Email Address of the user (also the username to login)
        public string EmailAddress { get; set; }

        [Required]
        //Password of the user. This should be hashed before being stored into the database.
        public string Password { get; set; }

        [Required]
        //Full name of the user. If a landlord, this is displayed on the listing.
        public string FullName {get; set;}

        [Required]
        //Phone number of the user. 
        public string PhoneNumber { get; set; }

    }
}
