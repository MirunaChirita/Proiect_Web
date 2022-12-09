﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Data;
using Proiect_Web.Models;

namespace Proiect_Web.Pages.Rezervari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public IndexModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        public IList<Rezervare> Rezervare { get;set; } = default!;

        public RezervareData RezervareD { get; set; }
        public int RezervareID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            RezervareD = new RezervareData();

            RezervareD.Rezervari = await _context.Rezervare
            .Include(b => b.ScoalaSchi)
            .Include(b => b.CategorieSport)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Monitor)
            .ToListAsync();
            if (id != null)
            {
                RezervareID = id.Value;
                Rezervare rezervare = RezervareD.Rezervari
                .Where(i => i.ID == id.Value).Single();
                RezervareD.Categorii = rezervare.CategorieSport.Select(s => s.Categorie);
            }
        }
        public async Task OnGetAsync()
        {
            if (_context.Rezervare != null)
            {
                Rezervare = await _context.Rezervare.Include(b => b.Monitor).Include(b=>b.ScoalaSchi).ToListAsync();

            }
        }
    }
}
