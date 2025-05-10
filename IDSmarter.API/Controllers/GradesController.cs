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
    public class GradesController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public GradesController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grades>>> GetGrade()
        {
            return await _context.Grade.ToListAsync();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grades>> GetGrades(int id)
        {
            var grades = await _context.Grade.FindAsync(id);

            if (grades == null)
            {
                return NotFound();
            }

            return grades;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrades(int id, Grades grades)
        {
            if (id != grades.Id)
            {
                return BadRequest();
            }

            _context.Entry(grades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradesExists(id))
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

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grades>> PostGrades(Grades grades)
        {
            _context.Grade.Add(grades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrades", new { id = grades.Id }, grades);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrades(int id)
        {
            var grades = await _context.Grade.FindAsync(id);
            if (grades == null)
            {
                return NotFound();
            }

            _context.Grade.Remove(grades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradesExists(int id)
        {
            return _context.Grade.Any(e => e.Id == id);
        }
    }
}
