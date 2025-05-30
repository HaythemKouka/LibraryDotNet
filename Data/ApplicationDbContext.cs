using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibrairieReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
              .HasKey(l => l.Id); // EF va générer un serial automatiquement pour PostgreSQL 9.3


            modelBuilder.Entity<Utilisateur>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Reservation>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Livre)
                .WithMany(l => l.Reservations)
                .HasForeignKey(r => r.LivreId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Utilisateur)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UtilisateurId);

            modelBuilder.Entity<Auteur>()
             .HasKey(l => l.Id);  // ← cette méthode est propre à Npgsql
        }

    }
}
