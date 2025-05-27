using Microsoft.EntityFrameworkCore;

namespace LibrairieReservation.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}