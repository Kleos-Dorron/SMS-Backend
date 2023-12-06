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
    public class AllocateSubjectsController : ControllerBase
    {
        private readonly SmsDbContext _context;

        public AllocateSubjectsController(SmsDbContext context)
        {
            _context = context;
        }

        // GET: api/AllocateSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllocateSubject>>> GetAllocateSubjects()
        {
          if (_context.AllocateSubjects == null)
          {
              return NotFound();
          }
            return await _context.AllocateSubjects.ToListAsync();
        }

        // GET: api/AllocateSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllocateSubject>> GetAllocateSubject(int id)
        {
          if (_context.AllocateSubjects == null)
          {
              return NotFound();
          }
            var allocateSubject = await _context.AllocateSubjects.FindAsync(id);

            if (allocateSubject == null)
            {
                return NotFound();
            }

            return allocateSubject;
        }

        // PUT: api/AllocateSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllocateSubject(int id, AllocateSubject allocateSubject)
        {
            if (id != allocateSubject.AllocateSubjectId)
            {
                return BadRequest();
            }

            _context.Entry(allocateSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocateSubjectExists(id))
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

        // POST: api/AllocateSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllocateSubject>> PostAllocateSubject(AllocateSubject allocateSubject)
        {
          if (_context.AllocateSubjects == null)
          {
              return Problem("Entity set 'SmsDbContext.AllocateSubjects'  is null.");
          }
            _context.AllocateSubjects.Add(allocateSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllocateSubject", new { id = allocateSubject.AllocateSubjectId }, allocateSubject);
        }

        // DELETE: api/AllocateSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocateSubject(int id)
        {
            if (_context.AllocateSubjects == null)
            {
                return NotFound();
            }
            var allocateSubject = await _context.AllocateSubjects.FindAsync(id);
            if (allocateSubject == null)
            {
                return NotFound();
            }

            _context.AllocateSubjects.Remove(allocateSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllocateSubjectExists(int id)
        {
            return (_context.AllocateSubjects?.Any(e => e.AllocateSubjectId == id)).GetValueOrDefault();
        }
    }
}
