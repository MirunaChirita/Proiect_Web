namespace Proiect_Web.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string CategorieNume{ get; set; }
        public ICollection<CategorieSport>? CategoriiSport { get; set; }
    }
}
