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
    public class StrandsController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public StrandsController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/Strands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Strands>>> GetStrand()
        {
            return await _context.Strand.ToListAsync();
        }

        // GET: api/Strands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Strands>> GetStrands(int id)
        {
            var strands = await _context.Strand.FindAsync(id);

            if (strands == null)
            {
                return NotFound();
            }

            return strands;
        }

        // PUT: api/Strands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrands(int id, Strands strands)
        {
            if (id != strands.Id)
            {
                return BadRequest();
            }

            _context.Entry(strands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrandsExists(id))
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

        // POST: api/Strands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Strands>> PostStrands(Strands strands)
        {
            _context.Strand.Add(strands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrands", new { id = strands.Id }, strands);
        }

        // DELETE: api/Strands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStrands(int id)
        {
            var strands = await _context.Strand.FindAsync(id);
            if (strands == null)
            {
                return NotFound();
            }

            _context.Strand.Remove(strands);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StrandsExists(int id)
        {
            return _context.Strand.Any(e => e.Id == id);
        }
    }
}
