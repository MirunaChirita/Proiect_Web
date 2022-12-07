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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public DetailsModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

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
    }
}
