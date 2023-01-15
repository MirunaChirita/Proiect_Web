using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Web.Models
{
    public class Monitor
    {
        public int ID { get; set; }
       
        public string? Nume { get; set; }
        public string? Prenume { get; set; }

        public string NumeComplet
        {
          get 
            { 
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Rezervare>? Rezervari { get; set; }

    }
}
