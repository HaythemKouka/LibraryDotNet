using System;

namespace LibrairieReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int LivreId { get; set; }
        public Livre Livre { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public DateTime DateReservation { get; set; } = DateTime.Now;
        public bool Valide { get; set; }
    }
}
