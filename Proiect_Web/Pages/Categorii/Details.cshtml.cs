using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.Categorii
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public DetailsModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

      public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.ID == id);
            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }
    }
}
