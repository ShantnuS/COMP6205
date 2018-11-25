using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelloHomes.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloHomes.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var personService = new PersonService();
            var person =  await personService.FindByEmailAsync(EmailAddress, Password);

            var isValidUser = person != null;
            string PersonFullName = "Null";

            if (!isValidUser)
            {
                ModelState.AddModelError("", "Invalid email or password");
            }
            else
            {
                PersonFullName = person.FullName;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, person.EmailAddress) },
                    scheme
                ));

            string returnURL = Request.Query["ReturnUrl"];

            if(returnURL == null)
            {
                returnURL = "/Index";
            }

            Response.Redirect(returnURL);
            return SignIn(user, scheme);
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}