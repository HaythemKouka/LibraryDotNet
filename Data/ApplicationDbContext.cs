using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Models;

namespace LibrairieReservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livre>()
                .Property(l => l.Id)
                .UseSerialColumn();

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Id)
                .UseSerialColumn();

            modelBuilder.Entity<Reservation>()
                .Property(r => r.Id)
                .UseSerialColumn();

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Livre)
                .WithMany(l => l.Reservations)
                .HasForeignKey(r => r.LivreId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Utilisateur)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UtilisateurId);

            modelBuilder.Entity<Auteur>()
            .Property(a => a.Id)
            .UseSerialColumn(); // ← cette méthode est propre à Npgsql
        }

    }
}
