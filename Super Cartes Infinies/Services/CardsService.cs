using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    [Route("api/[controller]/[action]")]
        [ApiController]
    public class CardService
    {
        
        

            private readonly ApplicationDbContext _context;

            public CardService(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: CardController

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Card>>> getallcards()
            {
                var cards = _context.Cards;
                if (_context.Cards == null)
                {
                throw new Exception("Aucune carte existe!");
            }

                return cards;
            }


        
    }
}
