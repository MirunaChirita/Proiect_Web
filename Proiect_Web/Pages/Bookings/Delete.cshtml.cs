using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public DeleteModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.ID == id);

            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
             
                var rezervare = await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == booking.RezervareID);
                var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == booking.MemberID);
                if (member == null)
                {
                    return NotFound();
                }
                else
                {
                    Member = member;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }
            var booking = await _context.Booking.FindAsync(id);

            if (booking != null)
            {
                Booking = booking;
                _context.Booking.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
