using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LibrairieReservation.Models
{ 

    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string MotDePasse { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty; // Admin ou Client

        // One Utilisateur peut avoir plusieurs Reservations → One-to-Many
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
     
    
}
