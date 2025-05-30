using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrairieReservation.Models
{
    public class Auteur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;

        public string? Nationalite { get; set; }

        public string? Biographie { get; set; }

        // Un auteur peut avoir plusieurs livres
        public ICollection<Livre> Livres { get; set; } = new List<Livre>();
    }
}
