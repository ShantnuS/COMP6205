using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public class SeedProperties
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HelloHomesPropertyContext(
                serviceProvider.GetRequiredService<DbContextOptions<HelloHomesPropertyContext>>()))
            {
                // Look for any Properties.
                if (context.Property.Any())
                {
                    return;   // DB has been seeded
                }

                context.Property.AddRange(
                    new Property
                    {
                        Name = "1 London Road",
                        Description = "A very good property located on the riverside!",
                        Bedrooms = 5,
                        RentPerMonth = 350.44M,
                        LandlordID = 1,
                        LandlordName = "Admin Bob",
                        LandlordNumber = "0999",
                        ApprovalStatus = Property.ApprovalEnum.Approved,
                        ApprovalComment = "Looks good!"
                    },

                    new Property
                    {
                        Name = "55 Hartley Library",
                        Description = "I want to sell this library, there's too many books here!",
                        Bedrooms = 1,
                        RentPerMonth = 859.88M,
                        LandlordID = 1,
                        LandlordName = "Admin Bob",
                        LandlordNumber = "0999",
                        ApprovalStatus = Property.ApprovalEnum.Approved,
                        ApprovalComment = "Looks good!"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
