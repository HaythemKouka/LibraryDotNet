namespace LibrairieReservation.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string ISBN { get; set; }           // Ajouté : code ISBN
        public string Editeur { get; set; }        // Ajouté : éditeur
        public int AnneePublication { get; set; }  // Ajouté : année de publication
        public int Stock { get; set; }
    }
}