using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelloHomes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloHomes.Pages.Property
{
    public class PropertyModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            var id = long.Parse((string)RouteData.Values["id"]);

            return RedirectToPage("/AddEditProperty/");
        }
    }
}