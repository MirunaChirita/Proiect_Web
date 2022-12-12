using System.Security.Policy;
using Proiect_Web.Models;

namespace Proiect_Web.Models.ViewModels
{
    public class ScoalaSchiIndexData
    {
        public IEnumerable<ScoalaSchi> ScoliSchi { get; set; }
        public IEnumerable<Rezervare> Rezervari { get; set; }
    }
}
