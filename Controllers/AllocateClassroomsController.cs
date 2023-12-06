using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS_Backend.Models;

namespace SMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassroomsController : ControllerBase
    {
        private readonly SmsDbContext _context;

        public AllocateClassroomsController(SmsDbContext context)
        {
            _context = context;
        }

        // GET: api/AllocateClassrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllocateClassroom>>> GetAllocateClassrooms()
        {
          if (_context.AllocateClassrooms == null)
          {
              return NotFound();
          }
            return await _context.AllocateClassrooms.ToListAsync();
        }

        // GET: api/AllocateClassrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllocateClassroom>> GetAllocateClassroom(int id)
        {
          if (_context.AllocateClassrooms == null)
          {
              return NotFound();
          }
            var allocateClassroom = await _context.AllocateClassrooms.FindAsync(id);

            if (allocateClassroom == null)
            {
                return NotFound();
            }

            return allocateClassroom;
        }

        // PUT: api/AllocateClassrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllocateClassroom(int id, AllocateClassroom allocateClassroom)
        {
            if (id != allocateClassroom.AllocateClassroomId)
            {
                return BadRequest();
            }

            _context.Entry(allocateClassroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocateClassroomExists(id))
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

        // POST: api/AllocateClassrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllocateClassroom>> PostAllocateClassroom(AllocateClassroom allocateClassroom)
        {
          if (_context.AllocateClassrooms == null)
          {
              return Problem("Entity set 'SmsDbContext.AllocateClassrooms'  is null.");
          }
            _context.AllocateClassrooms.Add(allocateClassroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllocateClassroom", new { id = allocateClassroom.AllocateClassroomId }, allocateClassroom);
        }

        // DELETE: api/AllocateClassrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocateClassroom(int id)
        {
            if (_context.AllocateClassrooms == null)
            {
                return NotFound();
            }
            var allocateClassroom = await _context.AllocateClassrooms.FindAsync(id);
            if (allocateClassroom == null)
            {
                return NotFound();
            }

            _context.AllocateClassrooms.Remove(allocateClassroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllocateClassroomExists(int id)
        {
            return (_context.AllocateClassrooms?.Any(e => e.AllocateClassroomId == id)).GetValueOrDefault();
        }
    }
}
