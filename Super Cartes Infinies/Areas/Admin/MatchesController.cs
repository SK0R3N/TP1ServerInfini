using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Matches
        public async Task<IActionResult> Index()
        {
              return _context.Matches != null ? 
                          View(await _context.Matches.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Matches'  is null.");
        }

        // POST: Admin/Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Matches == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Matches'  is null.");
            }
            var match = await _context.Matches.FindAsync(id);



            if (match != null)
            {

                var eventsToDelete = _context.SerializedMatchEvents.Where(e => e.Match.Id == match.Id);
                _context.SerializedMatchEvents.RemoveRange(eventsToDelete);

                _context.Matches.Remove(match);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
          return (_context.Matches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
