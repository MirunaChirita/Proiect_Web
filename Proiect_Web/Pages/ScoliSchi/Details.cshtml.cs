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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public DetailsModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

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
    }
}
