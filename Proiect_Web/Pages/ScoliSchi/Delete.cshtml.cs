using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.ScoliSchi
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public DeleteModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ScoalaSchi ScoalaSchi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ScoalaSchi == null)
            {
                return NotFound();
            }

            var scoalaschi = await _context.ScoalaSchi.FirstOrDefaultAsync(m => m.ID == id);

            if (scoalaschi == null)
            {
                return NotFound();
            }
            else 
            {
                ScoalaSchi = scoalaschi;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ScoalaSchi == null)
            {
                return NotFound();
            }
            var scoalaschi = await _context.ScoalaSchi.FindAsync(id);

            if (scoalaschi != null)
            {
                ScoalaSchi = scoalaschi;
                _context.ScoalaSchi.Remove(ScoalaSchi);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
