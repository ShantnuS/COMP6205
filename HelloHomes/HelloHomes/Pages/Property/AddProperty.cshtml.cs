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
    public class AddPropertyModel : PageModel
    {
        [BindProperty]
        [Required]
        [Display(Name = "Property Name")]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "No. of Bedrooms")]
        public int Bedrooms { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Rent (£ pcm)")]
        public decimal RentPerMonth { get; set; }

        [BindProperty]
        [Display(Name = "Image of Property")]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var personService = new PersonService();
            var propertyService = new PropertyService();

            var person = await personService.FindByEmailAsync(User.Identity.Name);

            //Place to put data into
            Models.Property property = new Models.Property
            {
                Name = Name,
                Description = Description,
                Bedrooms = Bedrooms,
                RentPerMonth = RentPerMonth,
                LandlordID = person.Id,
                LandlordName = person.FullName,
                LandlordNumber = person.PhoneNumber,
                ApprovalStatus = Models.Property.ApprovalEnum.Pending,
                ApprovalComment = ""
            };

            if (Image != null)
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    await Image.CopyToAsync(stream);

                    property.Image = stream.ToArray();
                    property.ImageContentType = Image.ContentType;
                }
            }

            await propertyService.SaveAsync(property);
            return RedirectToPage("/List");
        }
    }   
}
