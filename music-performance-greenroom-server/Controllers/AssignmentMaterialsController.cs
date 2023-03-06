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
    public class AssignmentMaterialsController : ControllerBase
    {
        private readonly GreenroomDbContext _context;

        public AssignmentMaterialsController(GreenroomDbContext context)
        {
            _context = context;
        }

        // GET: api/AssignmentMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentMaterial>>> GetAssignmentMaterial()
        {
            return await _context.AssignmentMaterial.ToListAsync();
        }

        // GET: api/AssignmentMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentMaterial>> GetAssignmentMaterial(int id)
        {
            var assignmentMaterial = await _context.AssignmentMaterial.FindAsync(id);

            if (assignmentMaterial == null)
            {
                return NotFound();
            }

            return assignmentMaterial;
        }

        // PUT: api/AssignmentMaterials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignmentMaterial(int id, AssignmentMaterial assignmentMaterial)
        {
            if (id != assignmentMaterial.AssignmentMaterialId)
            {
                return BadRequest();
            }

            _context.Entry(assignmentMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentMaterialExists(id))
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

        // POST: api/AssignmentMaterials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignmentMaterial>> PostAssignmentMaterial(AssignmentMaterial assignmentMaterial)
        {
            _context.AssignmentMaterial.Add(assignmentMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignmentMaterial", new { id = assignmentMaterial.AssignmentMaterialId }, assignmentMaterial);
        }

        // DELETE: api/AssignmentMaterials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignmentMaterial(int id)
        {
            var assignmentMaterial = await _context.AssignmentMaterial.FindAsync(id);
            if (assignmentMaterial == null)
            {
                return NotFound();
            }

            _context.AssignmentMaterial.Remove(assignmentMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentMaterialExists(int id)
        {
            return _context.AssignmentMaterial.Any(e => e.AssignmentMaterialId == id);
        }
    }
}
