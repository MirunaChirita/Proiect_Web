using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Web.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? RezervareID { get; set; }
        public Rezervare? Rezervare { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }
    }
}
