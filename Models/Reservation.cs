using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LibrairieReservation.Models
{
   
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        // Relation avec Livre (Many Reservations to One Livre)
        [ForeignKey(nameof(Livre))]
        public int LivreId { get; set; }
        public Livre Livre { get; set; } = null!;

        // Relation avec Utilisateur (Many Reservations to One Utilisateur)
        [ForeignKey(nameof(Utilisateur))]
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        public DateTime DateReservation { get; set; }
    }
}
