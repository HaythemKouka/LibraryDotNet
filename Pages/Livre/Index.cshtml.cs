using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Data;
using LibrairieReservation.Models;

namespace LibrairieReservation.Pages.Livres
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Livre> Livres { get; set; } = new List<Livre>();

        [BindProperty]
        public Livre Livre { get; set; } = new Livre();

        public string MessageErreur { get; set; } = string.Empty;
        public string MessageSucces { get; set; } = string.Empty;

        public SelectList AuteursSelectList { get; set; } = null!;

        public async Task OnGetAsync()
        {
            Livres = await _context.Livres
                .Include(l => l.Auteur)
                .OrderBy(l => l.Titre)
                .ToListAsync();

            await PopulateAuteursSelectList();
        }

        public async Task<IActionResult> OnPostCreateOrEditAsync()
        {
            await PopulateAuteursSelectList(); // Re-populate for validation errors

          

            if (Livre.Id == 0) // Create new livre
            {
                _context.Livres.Add(Livre);
                MessageSucces = "Livre ajouté avec succès.";
            }
            else // Update existing livre
            {
                var livreToUpdate = await _context.Livres.FindAsync(Livre.Id);

                if (livreToUpdate == null)
                {
                    MessageErreur = "Livre non trouvé.";
                    return RedirectToPage();
                }

                livreToUpdate.Titre = Livre.Titre;
                livreToUpdate.AuteurId = Livre.AuteurId;
                livreToUpdate.ISBN = Livre.ISBN;
                livreToUpdate.MaisonEdition = Livre.MaisonEdition;
                livreToUpdate.AnneePublication = Livre.AnneePublication;
                livreToUpdate.NombrePages = Livre.NombrePages;
                livreToUpdate.Langue = Livre.Langue;
                livreToUpdate.Stock = Livre.Stock;

                _context.Livres.Update(livreToUpdate);
                MessageSucces = "Livre modifié avec succès.";
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageErreur = "Une erreur de concurrence est survenue. Veuillez réessayer.";
            }
            catch (DbUpdateException ex)
            {
                MessageErreur = $"Une erreur est survenue lors de l'enregistrement : {ex.Message}";
                if (ex.InnerException != null)
                {
                    MessageErreur += $" Détails: {ex.InnerException.Message}";
                }
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var livre = await _context.Livres.FindAsync(id);

            if (livre == null)
            {
                MessageErreur = "Livre non trouvé.";
                return RedirectToPage();
            }

            try
            {
                _context.Livres.Remove(livre);
                await _context.SaveChangesAsync();
                MessageSucces = "Livre supprimé avec succès.";
            }
            catch (DbUpdateException ex)
            {
                MessageErreur = $"Impossible de supprimer le livre. Il est peut-être lié à d'autres enregistrements (ex: réservations). Détails: {ex.Message}";
            }
            catch (System.Exception ex)
            {
                MessageErreur = $"Une erreur inattendue est survenue lors de la suppression : {ex.Message}";
            }

            return RedirectToPage();
        }

        private async Task PopulateAuteursSelectList()
        {
            var auteurs = await _context.Auteurs.OrderBy(a => a.Nom).ToListAsync();
            AuteursSelectList = new SelectList(auteurs, "Id", "Nom");
        }
    }
}