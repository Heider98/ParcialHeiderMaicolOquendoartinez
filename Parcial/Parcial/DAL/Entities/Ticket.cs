using System.ComponentModel.DataAnnotations;

namespace Parcial.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Fecha de uso")]
        public DateTime? UseDate { get; set; }

        [Display(Name = "¿Fué usada?")]
        public bool IsUsed { get; set; }

        [Display(Name = "Entrada por donde ingreso")]
        public string? EntranceGate { get; set; }
    }
}
