using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_performance_greenroom_server.Models;

namespace music_performance_greenroom_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly GreenroomDbContext _context;

        public AssignmentsController(GreenroomDbContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignment()
        {
            return await _context.Assignment.ToListAsync();
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignment.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        [HttpGet("getAssignmentsByCourseId/{courseId}")]
        public async Task<ActionResult<List<Assignment>>> GetAssignmentsByCourseId(int courseId)
        {
            return await _context.Assignment.Where(a => a.CourseId == courseId)
                                            .Include(a => a.AssignmentMaterials) 
                                            .ToListAsync();
        } 

        // PUT: api/Assignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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

        // POST: api/Assignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment)
        {
            _context.Assignment.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.AssignmentId }, assignment);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignment.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignment.Any(e => e.AssignmentId == id);
        }
    }
}
