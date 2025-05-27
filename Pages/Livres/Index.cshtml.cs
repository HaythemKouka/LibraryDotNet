
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Data;
using LibrairieReservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task OnGetAsync()
        {
            Livres = await _context.Livres.ToListAsync();
        }
    }
}
