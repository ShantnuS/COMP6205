using HelloHomes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public class SeedPeople
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HelloHomesPersonContext(
                serviceProvider.GetRequiredService<DbContextOptions<HelloHomesPersonContext>>()))
            {
                // Look for any movies.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context.Person.AddRange(
                    new Person
                    {
                        IsAdmin = true,
                        EmailAddress = "admin@hellohomes.net",
                        Password = "admin",
                        FullName = "Admin Bob",
                        PhoneNumber = "0999"
                    },

                    new Person
                    {
                        IsAdmin = false,
                        EmailAddress = "jim@hellohomes.net",
                        Password = "admin",
                        FullName = "Jim Bob",
                        PhoneNumber = "121313"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
