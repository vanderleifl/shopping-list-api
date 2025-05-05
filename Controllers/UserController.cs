using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;
using ShoppingListAPI.Settings;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public UserController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/user
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return Conflict("User with this email already exists.");
            }

            int id = _context.Users.OrderByDescending(u => u.Id).FirstOrDefault()?.Id + 1 ?? 1;
            user.Id = id;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            var jwt = _tokenService.GenerateToken(user);

            return Ok(new
            {
                user = new
                {
                    user.Id,
                    user.Name,
                    user.Email
                },
                token = jwt
            });
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}