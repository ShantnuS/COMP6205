using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelloHomes.Models;
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

        public async Task<IActionResult> OnPostAsync()
        {
            var personService = new PersonService();

            var pExist = await personService.FindByEmailAsync(EmailAddress);

            var isValidUser = pExist != null;

            if (isValidUser)
            {
                ModelState.AddModelError("", "Email already in use!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Place to put data into
            Person person = new Person
            {
                EmailAddress = EmailAddress,
                Password = PersonService.Hash(Password),
                FullName = FullName,
                PhoneNumber = PhoneNumber
            };

            await personService.SaveAsync(person);
            return RedirectToPage("/Account/Login");
        }
    }
}