using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloHomes.Pages.Account
{
    public class SignUpModel : PageModel
    {

        [BindProperty]
        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public void OnGet()
        {
        }
    }
}