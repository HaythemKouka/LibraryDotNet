using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Models;

namespace LibrairieReservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
