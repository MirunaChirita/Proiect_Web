using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.ScoliSchi
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public EditModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScoalaSchi ScoalaSchi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ScoalaSchi == null)
            {
                return NotFound();
            }

            var scoalaschi =  await _context.ScoalaSchi.FirstOrDefaultAsync(m => m.ID == id);
            if (scoalaschi == null)
            {
                return NotFound();
            }
            ScoalaSchi = scoalaschi;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScoalaSchi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoalaSchiExists(ScoalaSchi.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScoalaSchiExists(int id)
        {
          return _context.ScoalaSchi.Any(e => e.ID == id);
        }
    }
}
