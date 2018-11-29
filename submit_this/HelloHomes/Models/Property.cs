using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Environment;
using System.Security.Cryptography;

namespace HelloHomes.Models
{
    public class Property
    {
        public enum ApprovalEnum { Pending, Approved, Rejected }

        public long Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Hey - you've gotta give a name between 5 and 100 characters long!")]
        //Name of the property (i.e. "1 Baker Street")
        public string Name { get; set; }

        [Required]
        //Description of Property
        public string Description { get; set; }

        [Required]
        //Number of bedrooms in the property
        public int Bedrooms { get; set; }

        [Required]
        //Cost of property per month
        public decimal RentPerMonth { get; set; }

        [Required]
        //ID of Landlord 
        public long LandlordID { get; set; }

        [Required]
        //Name of landlord
        public string LandlordName { get; set; }

        [Required]
        //Phone number of landlord
        public string LandlordNumber { get; set; }

        [Required]
        /* Approval status of property
         * 0 = Pending
         * 1 = Approved 
         * 2 = Rejected
         */
        public ApprovalEnum ApprovalStatus { get; set; }

        [Required]
        //Reason for approval/rejection
        public string ApprovalComment { get; set; }

        #region Image 

        //Image of the property
        public byte[] Image { get; set; }

        //Image processing from J. Chadwick's Lynda Tutorial
        public string ImageContentType { get; set; }

        public string GetInlineImageSrc()
        {
            if (Image == null || ImageContentType == null)
                return null;

            var base64Image = System.Convert.ToBase64String(Image);
            return $"data:{ImageContentType};base64,{base64Image}";
        }

        public void SetImage(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null)
                return;

            ImageContentType = file.ContentType;

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                Image = stream.ToArray();
            }
        }
        #endregion
    }
}
