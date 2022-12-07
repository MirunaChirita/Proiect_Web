using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.Monitori
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public DeleteModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Monitor Monitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Monitor == null)
            {
                return NotFound();
            }

            var monitor = await _context.Monitor.FirstOrDefaultAsync(m => m.ID == id);

            if (monitor == null)
            {
                return NotFound();
            }
            else 
            {
                Monitor = monitor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Monitor == null)
            {
                return NotFound();
            }
            var monitor = await _context.Monitor.FindAsync(id);

            if (monitor != null)
            {
                Monitor = monitor;
                _context.Monitor.Remove(Monitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
