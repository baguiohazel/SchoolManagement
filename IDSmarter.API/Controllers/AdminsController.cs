
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IDSmarter.Domain.Entities;
using IDSmarter.Infrastructure.Data;

namespace IDSmarter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public AdminsController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admins>>> GetAdmin()
        {
            return await _context.Admin.ToListAsync();
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admins>> GetAdmins(int id)
        {
            var admins = await _context.Admin.FindAsync(id);

            if (admins == null)
            {
                return NotFound();
            }

            return admins;
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmins(int id, Admins admins)
        {
            if (id != admins.Id)
            {
                return BadRequest();
            }

            _context.Entry(admins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admins>> PostAdmins(Admins admins)
        {
            _context.Admin.Add(admins);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmins", new { id = admins.Id }, admins);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmins(int id)
        {
            var admins = await _context.Admin.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(admins);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminsExists(int id)
        {
            return _context.Admin.Any(e => e.Id == id);
        }
    }
}
