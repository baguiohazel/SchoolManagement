using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IDSmarter.Domain.Entities;
using IDSmarter.Infrastructure.Data;

namespace IDSmarter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreRegistrationsController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public PreRegistrationsController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/PreRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreRegistrations>>> GetPreRegistration()
        {
            return await _context.PreRegistration.ToListAsync();
        }

        // GET: api/PreRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreRegistrations>> GetPreRegistrations(int id)
        {
            var preRegistrations = await _context.PreRegistration.FindAsync(id);

            if (preRegistrations == null)
            {
                return NotFound();
            }

            return preRegistrations;
        }

        // PUT: api/PreRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreRegistrations(int id, PreRegistrations preRegistrations)
        {
            if (id != preRegistrations.Id)
            {
                return BadRequest();
            }

            _context.Entry(preRegistrations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreRegistrationsExists(id))
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

        // POST: api/PreRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreRegistrations>> PostPreRegistrations(PreRegistrations preRegistrations)
        {
            _context.PreRegistration.Add(preRegistrations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreRegistrations", new { id = preRegistrations.Id }, preRegistrations);
        }

        // DELETE: api/PreRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreRegistrations(int id)
        {
            var preRegistrations = await _context.PreRegistration.FindAsync(id);
            if (preRegistrations == null)
            {
                return NotFound();
            }

            _context.PreRegistration.Remove(preRegistrations);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreRegistrationsExists(int id)
        {
            return _context.PreRegistration.Any(e => e.Id == id);
        }
    }
}
