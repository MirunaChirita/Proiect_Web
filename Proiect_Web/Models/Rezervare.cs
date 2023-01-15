using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Web.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
        public int? MonitorID { get; set; }

        public Monitor? Monitor { get; set; }
        [Display(Name = "Nume Partie")]
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Partie { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
            [Range(0.01, 500)]

        public decimal Tarif { get; set; }

        [DataType(DataType.Date)]
        public string Echipament { get; set; }
        public string NrPersoane { get; set; }

        [Display(Name = "Data Programare")]

        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }
        public int? ScoalaSchiID { get; set; }
        public ScoalaSchi? ScoalaSchi { get; set; }
        public ICollection<CategorieSport>? CategorieSport { get; set; }
    }
}
