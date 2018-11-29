using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloHomes.Models
{
    public class HelloHomesPersonContext : DbContext
    {
        public HelloHomesPersonContext (DbContextOptions<HelloHomesPersonContext> options)
            : base(options)
        {
        }

        public DbSet<HelloHomes.Models.Person> Person { get; set; }
    }
}
