﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Web.Data.Proiect_WebContext _context;

        public IndexModel(Proiect_Web.Data.Proiect_WebContext context)
        {
            _context = context;
        }

        public IList<ScoalaSchi> ScoalaSchi { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ScoalaSchi != null)
            {
                ScoalaSchi = await _context.ScoalaSchi.ToListAsync();
            }
        }
    }
}
