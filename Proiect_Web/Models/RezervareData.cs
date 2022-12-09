namespace Proiect_Web.Models
{
    public class RezervareData
    {
        public IEnumerable<Rezervare> Rezervari { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieSport> CategoriiSport { get; set; }
    }
}
