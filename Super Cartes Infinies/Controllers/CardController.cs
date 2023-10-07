using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : BaseController
    {
        readonly UserManager<IdentityUser> UserManager;

        private readonly ApplicationDbContext _context;


        public CardController(ApplicationDbContext context, UserManager<IdentityUser> userManager,PlayersService playersService) :base(playersService)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: CardController

        [HttpGet]
        public ActionResult<IEnumerable<Card>> getallcards()
        {
            var cards = _context.Cards;
            if (_context.Cards == null)
            {
                return NotFound(new { Error = "Aucune carte existe!" });
            }

            return cards;
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCard(int id)
        {
            var card = _context.Cards.FirstOrDefaultAsync(m => m.Id == id).Result;
            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetCardsFromPlayer()
        {
            Player player = playersService.GetPlayerFromUserId(UserId);
            var cards = player.Cartes.ToArray();
            if (_context.Cards == null)
            {
                return NotFound(new { Error = "Aucune carte existe!" });
            }

            return cards;
        }
    }
}
