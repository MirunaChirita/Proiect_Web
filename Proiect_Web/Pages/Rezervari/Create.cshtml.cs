using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.Rezervari
{
    public class CreateModel : CategorieSportPageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public CreateModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ScoalaSchiID"] = new SelectList(_context.Set<ScoalaSchi>(), "ID",
"NumeScoalaSchi");
            ViewData["MonitorID"] = new SelectList(_context.Set<Models.Monitor>(), "ID",
"NumeComplet");
            var rezervare = new Rezervare();
            rezervare.CategorieSport = new List<CategorieSport>();
            PopulateAssignedCategoryData(_context, rezervare);
            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRezervare = new Rezervare();
            if (selectedCategories != null)
            {
                newRezervare.CategorieSport = new List<CategorieSport>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieSport
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newRezervare.CategorieSport.Add(catToAdd);
                }
            }
            Rezervare.CategorieSport = newRezervare.CategorieSport;
            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newRezervare);
            return Page();
        }
        
    }
}

