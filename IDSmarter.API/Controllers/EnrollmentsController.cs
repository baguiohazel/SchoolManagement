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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public EnrollmentsController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/Enrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollments>>> GetEnrollment()
        {
            return await _context.Enrollment.ToListAsync();
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollments>> GetEnrollments(int id)
        {
            var enrollments = await _context.Enrollment.FindAsync(id);

            if (enrollments == null)
            {
                return NotFound();
            }

            return enrollments;
        }

        // PUT: api/Enrollments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollments(int id, Enrollments enrollments)
        {
            if (id != enrollments.Id)
            {
                return BadRequest();
            }

            _context.Entry(enrollments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentsExists(id))
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

        // POST: api/Enrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enrollments>> PostEnrollments(Enrollments enrollments)
        {
            _context.Enrollment.Add(enrollments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnrollmentsExists(enrollments.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnrollments", new { id = enrollments.Id }, enrollments);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollments(int id)
        {
            var enrollments = await _context.Enrollment.FindAsync(id);
            if (enrollments == null)
            {
                return NotFound();
            }

            _context.Enrollment.Remove(enrollments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnrollmentsExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
