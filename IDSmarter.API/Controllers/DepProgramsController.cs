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
    public class DepProgramsController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public DepProgramsController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/DepPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepPrograms>>> GetDepProgram()
        {
            return await _context.DepProgram.ToListAsync();
        }

        // GET: api/DepPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepPrograms>> GetDepPrograms(int id)
        {
            var depPrograms = await _context.DepProgram.FindAsync(id);

            if (depPrograms == null)
            {
                return NotFound();
            }

            return depPrograms;
        }

        // PUT: api/DepPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepPrograms(int id, DepPrograms depPrograms)
        {
            if (id != depPrograms.Id)
            {
                return BadRequest();
            }

            _context.Entry(depPrograms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepProgramsExists(id))
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

        // POST: api/DepPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepPrograms>> PostDepPrograms(DepPrograms depPrograms)
        {
            _context.DepProgram.Add(depPrograms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepPrograms", new { id = depPrograms.Id }, depPrograms);
        }

        // DELETE: api/DepPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepPrograms(int id)
        {
            var depPrograms = await _context.DepProgram.FindAsync(id);
            if (depPrograms == null)
            {
                return NotFound();
            }

            _context.DepProgram.Remove(depPrograms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepProgramsExists(int id)
        {
            return _context.DepProgram.Any(e => e.Id == id);
        }
    }
}
