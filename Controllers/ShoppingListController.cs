using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShoppingListController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/shoppinglist
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingList>>> GetAll()
        {
            return await _context.ShoppingLists
                .Include(l => l.Items)
                .ToListAsync();
        }

        // POST: api/shoppinglist
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ShoppingList>> Create([FromBody]ShoppingList shoppingList)
        {
            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = shoppingList.Id }, shoppingList);
        }

        // GET: api/shoppinglist/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> GetById(int id)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(l => l.Items)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return shoppingList;
        }

        // PUT: api/shoppinglist/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShoppingList shoppingList)
        {
            if (id != shoppingList.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return NotFound($"Error: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/shoppinglist/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}