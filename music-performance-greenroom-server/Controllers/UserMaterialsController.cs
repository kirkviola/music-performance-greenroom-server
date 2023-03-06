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
    public class UserMaterialsController : ControllerBase
    {
        private readonly GreenroomDbContext _context;

        public UserMaterialsController(GreenroomDbContext context)
        {
            _context = context;
        }

        // GET: api/UserMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMaterial>>> GetUserMaterial()
        {
            return await _context.UserMaterial.ToListAsync();
        }

        // GET: api/UserMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMaterial>> GetUserMaterial(int id)
        {
            var userMaterial = await _context.UserMaterial.FindAsync(id);

            if (userMaterial == null)
            {
                return NotFound();
            }

            return userMaterial;
        }

        // PUT: api/UserMaterials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMaterial(int id, UserMaterial userMaterial)
        {
            if (id != userMaterial.UserMaterialId)
            {
                return BadRequest();
            }

            _context.Entry(userMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMaterialExists(id))
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

        // POST: api/UserMaterials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserMaterial>> PostUserMaterial(UserMaterial userMaterial)
        {
            _context.UserMaterial.Add(userMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMaterial", new { id = userMaterial.UserMaterialId }, userMaterial);
        }

        // DELETE: api/UserMaterials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMaterial(int id)
        {
            var userMaterial = await _context.UserMaterial.FindAsync(id);
            if (userMaterial == null)
            {
                return NotFound();
            }

            _context.UserMaterial.Remove(userMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMaterialExists(int id)
        {
            return _context.UserMaterial.Any(e => e.UserMaterialId == id);
        }
    }
}
