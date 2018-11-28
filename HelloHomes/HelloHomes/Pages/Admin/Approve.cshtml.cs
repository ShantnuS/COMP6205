using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelloHomes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloHomes.Pages.Admin
{
    public class ApproveModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Description { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var id = long.Parse((string)RouteData.Values["id"]);

            if (Description.Equals(""))
            {
                ModelState.AddModelError("", "Please leave a comment!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var propertyService = new PropertyService();
            await propertyService.UpdateApprovalStatusAsync(id, Models.Property.ApprovalEnum.Approved, Description);
            return RedirectToPage("/Admin/Admin");
        }
    }
}