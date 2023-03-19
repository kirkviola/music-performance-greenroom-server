using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_performance_greenroom_server.Models;

namespace GreenroomServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly GreenroomDbContext _context;

        public MaterialsController(GreenroomDbContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterial()
        {
          if (_context.Material == null)
          {
              return NotFound();
          }
            return await _context.Material.ToListAsync();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
          if (_context.Material == null)
          {
              return NotFound();
          }
            var material = await _context.Material.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        [HttpGet("getMaterialsByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterialsByUserId(int id)
        {
            var materials = await _context.Material.Where(mat => mat.UserId == id).ToListAsync();
            
            if (materials == null)
            {
                return NotFound();
            }

            return materials;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
          if (_context.Material == null)
          {
              return Problem("Entity set 'GreenroomDbContext.Material'  is null.");
          }
            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            if (_context.Material == null)
            {
                return NotFound();
            }
            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Material.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return (_context.Material?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
