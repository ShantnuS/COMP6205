using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using HelloHomes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace HelloHomes.Pages.Property
{
    public class AddEditPropertyModel : PageModel
    {
        [FromRoute]
        public long Id { get; set; }

        public async Task<bool> IsNewProperty()
        {
            return Id >= (await propertyService.GetAllAsync()).Length;
        }
        
        [BindProperty]
        [Required]
        [Display(Name = "Property Name")]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.MultilineText)]
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

        private PropertyService propertyService = new PropertyService();

        public async Task<IActionResult> OnPostAsync()
        {
            var personService = new PersonService();

            var person = await personService.FindByEmailAsync(User.Identity.Name);

            Description = this.Request.Form["Description"];

            //Place to put data into
            Models.Property property = new Models.Property
            {
                Id = Id,
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
                using (var stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);

                    property.Image = stream.ToArray();
                    property.ImageContentType = Image.ContentType;
                }
            }

            await propertyService.SaveAsync(property);
            return RedirectToPage("/Property/List");
        }

        public void Put(IFormFile formFile)
        {
            Image = formFile;
        }

        public async Task<IActionResult> OnDeleteAsync()
        {
            propertyService.RemovePropertyAsync(Id);
            return RedirectToPage("/Property/List");
        }
    }   
}
