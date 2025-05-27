using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Data;
using LibrairieReservation.Models;

namespace LibrairieReservation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LivresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/livres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livre>>> GetLivres()
        {
            return await _context.Livres.ToListAsync();
        }

        // GET: api/livres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livre>> GetLivre(int id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre == null) return NotFound();
            return livre;
        }

        // POST: api/livres
        [HttpPost]
        public async Task<ActionResult<Livre>> PostLivre(Livre livre)
        {
            _context.Livres.Add(livre);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLivre), new { id = livre.Id }, livre);
        }

        // PUT: api/livres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivre(int id, Livre livre)
        {
            if (id != livre.Id) return BadRequest();

            _context.Entry(livre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Livres.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/livres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivre(int id)
        {
            var livre = await _context.Livres.FindAsync(id);
            if (livre == null) return NotFound();

            _context.Livres.Remove(livre);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
