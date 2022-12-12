using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;
using Proiect_Web.Models.ViewModels;

namespace Proiect_Web.Pages.ScoliSchi
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public IndexModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        public IList<ScoalaSchi> ScoalaSchi { get;set; } = default!;

        public ScoalaSchiIndexData ScoalaSchiData { get; set; }
        public int ScoalaSchiID { get; set; }
        public int RezervareID { get; set; }
        public async Task OnGetAsync(int? id, int? rezervareID)
        {
            ScoalaSchiData = new ScoalaSchiIndexData();
            ScoalaSchiData.ScoliSchi = await _context.ScoalaSchi
            .Include(i => i.Rezervari)
            .ThenInclude(c => c.Monitor)
            .OrderBy(i => i.NumeScoalaSchi)
            .ToListAsync();
            if (id != null)
            {
                ScoalaSchiID = id.Value;
                ScoalaSchi scoalaSchi = ScoalaSchiData.ScoliSchi
                .Where(i => i.ID == id.Value).Single();
                ScoalaSchiData.Rezervari = scoalaSchi.Rezervari;
            }
        }
    }
}
