using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibrairieReservation.Data;
using LibrairieReservation.Models;
using System.Threading.Tasks;

namespace LibrairieReservation.Pages.Livres
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livre Livre { get; set; } = new Livre();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Livres.Add(Livre);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
