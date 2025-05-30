using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LibrairieReservation.Models
{
    public class Livre
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [Display(Name = "Titre")]
        public string Titre { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'auteur est obligatoire")]
        [Display(Name = "Auteur")]
        public int AuteurId { get; set; }

        [ForeignKey("AuteurId")]
        public Auteur Auteur { get; set; } = null!;

        [Display(Name = "ISBN")]
        public string? ISBN { get; set; }

        [Display(Name = "Maison d'édition")]
        public string? MaisonEdition { get; set; }

        [Required(ErrorMessage = "L'année de publication est obligatoire")]
        [Display(Name = "Année de publication")]
        [Range(1000, 9999, ErrorMessage = "L'année doit être comprise entre 1000 et 9999")]
        public int AnneePublication { get; set; }

        [Required(ErrorMessage = "Le nombre de pages est obligatoire")]
        [Display(Name = "Nombre de pages")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de pages doit être supérieur à 0")]
        public int NombrePages { get; set; }

        [Display(Name = "Langue")]
        public string? Langue { get; set; }

        [Required(ErrorMessage = "Le stock est obligatoire")]
        [Display(Name = "Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Le stock ne peut pas être négatif")]
        public int Stock { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
