using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloHomes.Models
{
    public class HelloHomesPropertyContext : DbContext
    {
        public HelloHomesPropertyContext (DbContextOptions<HelloHomesPropertyContext> options)
            : base(options)
        {
        }

        public DbSet<HelloHomes.Models.Property> Property { get; set; }
    }
}
