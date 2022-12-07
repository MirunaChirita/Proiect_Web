namespace Proiect_Web.Models
{
    public class ScoalaSchi
    {
        public int ID { get; set; }
        public string NumeScoalaSchi { get; set; }
        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
