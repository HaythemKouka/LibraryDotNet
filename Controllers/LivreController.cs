using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Models;
using LibrairieReservation.Data;

namespace LibrairieReservation.Controllers
{
    public class LivreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livre
        public async Task<IActionResult> Index()
        {
            ViewData["Auteurs"] = await _context.Auteurs.ToListAsync();
            var livres = await _context.Livres
                .Include(l => l.Auteur)
                .ToListAsync();
            return View(livres);
        }

        // GET: Livre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres
                .Include(l => l.Auteur)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // GET: Livre/Create
        public IActionResult Create()
        {
            ViewData["Auteurs"] = _context.Auteurs.ToList();
            return View();
        }

        // POST: Livre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titre,AuteurId,ISBN,MaisonEdition,AnneePublication,NombrePages,Langue,Stock")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livre);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Le livre a été ajouté avec succès.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Auteurs"] = await _context.Auteurs.ToListAsync();
            return View(livre);
        }

        // GET: Livre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }
            ViewData["Auteurs"] = _context.Auteurs.ToList();
            return View(livre);
        }

        // POST: Livre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Titre,AuteurId,ISBN,MaisonEdition,AnneePublication,NombrePages,Langue,Stock")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livre);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Le livre a été modifié avec succès.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreExists(livre.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Auteurs"] = await _context.Auteurs.ToListAsync();
            return View(livre);
        }

        // GET: Livre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres
                .Include(l => l.Auteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // POST: Livre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre != null)
            {
                _context.Livres.Remove(livre);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Le livre a été supprimé avec succès.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LivreExists(int id)
        {
            return _context.Livres.Any(e => e.Id == id);
        }
    }
} 