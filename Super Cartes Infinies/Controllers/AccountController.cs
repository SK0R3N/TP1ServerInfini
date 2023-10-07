
using Cours2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cours2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly UserManager<IdentityUser> UserManager;
        readonly ApplicationDbContext _context;
        readonly SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe spécifiés sont différents." });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = register.Email,
                Email = register.Email
            };

            IdentityResult identityResult = await UserManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création de l'utilisateur a échoué." });
            }

            List<Card> cartesDb = _context.Cards.Where(c => c.CarteDepart == true).ToList();

            // Mélangez la liste des cartes de manière aléatoire.
            Random random = new Random();
            cartesDb = cartesDb.OrderBy(c => random.Next()).ToList();

            int nombreDeCartesAleatoires = 7; // la quantité souhaitée
            List<Card> cartesAssignees = cartesDb.Take(nombreDeCartesAleatoires).ToList();

            Player player = new Player()
            {
                IdentityUser = user,
                Name = user.Email,
                IdentityUserId = user.Id,
                Cartes = cartesAssignees
            };

            _context.Players.Add(player);
            _context.SaveChanges();

            return Ok(new { Message = "Inscription réussie ! 🥳" });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var result = await SignInManager.PasswordSignInAsync(login.Email, login.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok();
            }

            return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
        }

        [Authorize]
        public ActionResult<string[]> Data()
        {
            return new string[] { "figue", "banane", "noix" };
        }

        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok();
        }
    }
}
