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

namespace Proiect_Web.Pages.Rezervari
{
    public class EditModel : CategorieSportPageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public EditModel(Proiect_Web.Data.Proiect_WebContext context)
        {

            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }
            Rezervare = await _context.Rezervare
                 .Include(b => b.ScoalaSchi)
                 .Include(b => b.CategorieSport).ThenInclude(b => b.Categorie)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            var rezervare =  await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Rezervare);
            Rezervare = rezervare;
            ViewData["ScoalaSchiID"] = new SelectList(_context.Set<ScoalaSchi>(), "ID",
"NumeScoalaSchi");
            ViewData["MonitorID"] = new SelectList(_context.Set<Models.Monitor>(), "ID",
"NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {

            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var rezervareToUpdate = await _context.Rezervare
            .Include(i => i.ScoalaSchi)
            .Include(i => i.CategorieSport)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (rezervareToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Rezervare>(
            rezervareToUpdate,
            "Rezervare",
            i => i.Monitor, i => i.Partie,
            i => i.Tarif, i => i.Echipament, i => i.NrPersoane, i => i.DataProgramare, i => i.ScoalaSchiID, i => i.CategorieSport))
            {
                UpdateSportCategories(_context, selectedCategories, rezervareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateSportCategories(_context, selectedCategories, rezervareToUpdate);
            PopulateAssignedCategoryData(_context, rezervareToUpdate);
            return Page();
        }
    }
}
