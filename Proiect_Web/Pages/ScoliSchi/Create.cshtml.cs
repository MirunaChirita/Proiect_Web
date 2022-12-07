using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.ScoliSchi
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public CreateModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScoalaSchi ScoalaSchi { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ScoalaSchi.Add(ScoalaSchi);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
