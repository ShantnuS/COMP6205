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
    public class DeleteModel : PageModel
    {
        private readonly HelloHomes.Models.HelloHomesContext _context;

        public DeleteModel(HelloHomes.Models.HelloHomesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Property.FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Property.FindAsync(id);

            if (Property != null)
            {
                _context.Property.Remove(Property);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
