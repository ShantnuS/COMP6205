using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Environment;

namespace HelloHomes.Models
{
    public class Property
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Hey - you've gotta give a name between 5 and 100 characters long!")]
        //Name of the property (i.e. "1 Baker Street")
        public string Name { get; set; }

        [Required]
        //Description of Property
        public string Description { get; set; }

        //Image of the property
        public byte[] Image { get; set; }

        //Number of bedrooms in the property
        public int Bedrooms { get; set; }

        //Cost of property per month
        public decimal RentPerMonth { get; set; }

        //ID of Landlord 
        public long LandlordID { get; set; }

        //Name of landlord
        public string LandlordName { get; set; }

        //Phone number of landlord
        public string LandlordNumber { get; set; }

        /* Approval status of property
         * 0 = Pending
         * 1 = Approved 
         * 2 = Rejected
         */
        public int ApprovalStatus { get; set; }
    }
}
