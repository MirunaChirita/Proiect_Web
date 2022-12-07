using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Web.Models
{
    public class Monitor
    {
        public int ID { get; set; }
       
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public ICollection<Rezervare>? Rezervari { get; set; }

    }
}
