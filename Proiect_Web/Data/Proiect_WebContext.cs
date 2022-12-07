using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Web.Models;

namespace Proiect_Web.Data
{
    public class Proiect_WebContext : DbContext
    {
        public Proiect_WebContext (DbContextOptions<Proiect_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Web.Models.Rezervare> Rezervare { get; set; } = default!;

        public DbSet<Proiect_Web.Models.ScoalaSchi> ScoalaSchi { get; set; }

        public DbSet<Proiect_Web.Models.Monitor> Monitor { get; set; }
    }
}
