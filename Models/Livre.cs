using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LibrairieReservation.Models
{
    public class Livre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; } = string.Empty;

        [Required]
        public string Auteur { get; set; } = string.Empty;

        public int Stock { get; set; }

        // One Livre peut avoir plusieurs Reservations → One-to-Many
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }


}
