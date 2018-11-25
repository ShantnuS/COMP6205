using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloHomes.Models
{
    public class HelloHomesContext : DbContext
    {
        public HelloHomesContext (DbContextOptions<HelloHomesContext> options)
            : base(options)
        {
        }

        public DbSet<HelloHomes.Models.Property> Property { get; set; }
    }
}
