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

        public IActionResult OnPost()
        {
            var isValidUser = EmailAddress == "admin" && Password == "password";

            //Example of using models to retrieve things
            var person = new Person();

            string PersonFullName = person.FullName;

            if (PersonFullName == null)
            {
                PersonFullName = "Jimbo";
            }
            //End Example

            if (!isValidUser)
            {
                ModelState.AddModelError("", "Invalid email or password");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    //new[] { new Claim(ClaimTypes.Name, EmailAddress) },
                    new[] { new Claim(ClaimTypes.Name, PersonFullName) },
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