using LibrairieReservation.Data;
using LibrairieReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrairieReservation.Pages.Auteurs
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public IndexModel(ApplicationDbContext context)
		{
			_context = context;
		}

		// Liste des auteurs affichée dans la page
		public IList<Auteur> Auteurs { get; set; } = new List<Auteur>();

		// Propriété bindée pour la création/modification
		[BindProperty]
		public Auteur Auteur { get; set; } = new Auteur();

		// Messages temporaires pour feedback utilisateur
		[TempData]
		public string MessageErreur { get; set; } = string.Empty;

		[TempData]
		public string MessageSucces { get; set; } = string.Empty;

		// Chargement des auteurs à l'affichage
		public async Task OnGetAsync()
		{
			Auteurs = await _context.Auteurs
				.Include(a => a.Livres)  // Chargement des livres liés pour vérification suppression
				.AsNoTracking()
				.ToListAsync();
		}

		// Création ou modification d'un auteur
		public async Task<IActionResult> OnPostCreateOrEditAsync()
		{
			if (!ModelState.IsValid)
			{
				MessageErreur = "Données invalides.";
				await LoadAuteursAsync();
				return Page();
			}

			if (Auteur.Id == 0)
			{
				// Création
				_context.Auteurs.Add(Auteur);
			}
			else
			{
				// Modification
				var auteurEnBase = await _context.Auteurs.FindAsync(Auteur.Id);
				if (auteurEnBase == null)
				{
					MessageErreur = "Auteur non trouvé.";
					await LoadAuteursAsync();
					return Page();
				}

				auteurEnBase.Nom = Auteur.Nom;
				auteurEnBase.Nationalite = Auteur.Nationalite;
				auteurEnBase.Biographie = Auteur.Biographie;
			}

			await _context.SaveChangesAsync();
			MessageSucces = "Opération réussie.";
			return RedirectToPage();
		}

		// Suppression d'un auteur (vérifie s'il a des livres)
		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var auteur = await _context.Auteurs
				.Include(a => a.Livres)
				.FirstOrDefaultAsync(a => a.Id == id);

			if (auteur == null)
			{
				MessageErreur = "Auteur non trouvé.";
				await LoadAuteursAsync();
				return Page();
			}

			if (auteur.Livres.Count > 0)
			{
				MessageErreur = "Impossible de supprimer un auteur qui a des livres.";
				await LoadAuteursAsync();
				return Page();
			}

			_context.Auteurs.Remove(auteur);
			await _context.SaveChangesAsync();

			MessageSucces = "Auteur supprimé avec succès.";
			return RedirectToPage();
		}

		// Chargement des auteurs (réutilisé en cas d'erreur pour afficher la liste)
		private async Task LoadAuteursAsync()
		{
			Auteurs = await _context.Auteurs
				.Include(a => a.Livres)
				.AsNoTracking()
				.ToListAsync();
		}
	}
}
