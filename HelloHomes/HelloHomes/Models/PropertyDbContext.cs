using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloHomes.Models
{
    public class PropertyDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }

        public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
            :base(options)
        {
            //this.EnsureSeedData();
        }
    }
}
