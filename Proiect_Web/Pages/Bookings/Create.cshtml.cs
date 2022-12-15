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

namespace Proiect_Web.Pages.Bookings
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
            var rezervareList = _context.Rezervare
             .Include(b => b.Monitor)
             .Select(x => new
        {
                 x.ID,
                 RezervareCompleta = x.Partie + " - " + x.Monitor.Nume + " " + x.Monitor.Prenume
             });
            ViewData["RezervareID"] = new SelectList(rezervareList, "ID","RezervareCompleta");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID","FullName");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
