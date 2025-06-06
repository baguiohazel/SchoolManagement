﻿using System;
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
    public class SchedulesController : ControllerBase
    {
        private readonly IDSmarterDbContext _context;

        public SchedulesController(IDSmarterDbContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedules>>> GetSchedul()
        {
            return await _context.Schedul.ToListAsync();
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedules>> GetSchedules(int id)
        {
            var schedules = await _context.Schedul.FindAsync(id);

            if (schedules == null)
            {
                return NotFound();
            }

            return schedules;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedules(int id, Schedules schedules)
        {
            if (id != schedules.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedulesExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedules>> PostSchedules(Schedules schedules)
        {
            _context.Schedul.Add(schedules);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedules", new { id = schedules.Id }, schedules);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedules(int id)
        {
            var schedules = await _context.Schedul.FindAsync(id);
            if (schedules == null)
            {
                return NotFound();
            }

            _context.Schedul.Remove(schedules);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchedulesExists(int id)
        {
            return _context.Schedul.Any(e => e.Id == id);
        }
    }
}
