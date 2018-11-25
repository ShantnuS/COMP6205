using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelloHomes.Models;

namespace HelloHomes
{
    public class IndexModel : PageModel
    {
        private readonly HelloHomes.Models.HelloHomesContext _context;

        public IndexModel(HelloHomes.Models.HelloHomesContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; }

        public async Task OnGetAsync()
        {
            Property = await _context.Property.ToListAsync();
        }
    }
}
