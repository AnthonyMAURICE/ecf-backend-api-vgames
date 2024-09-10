using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecf.Vgames.Db;
using Ecf.Vgames.Models;

namespace Ecf.Vgames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GizmondosController : ControllerBase
    {
        private readonly GizmondoContext _context;

        public GizmondosController(GizmondoContext context)
        {
            _context = context;
        }

        // GET: api/Gizmondos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gizmondos>>> GetGizmondoes()
        {
            return await _context.Gizmondos.ToListAsync();
        }

        // GET: api/Gizmondos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gizmondos>> GetGizmondos(int id)
        {

            if (_context.Gizmondos == null)
            {
                return NoContent();
            }


            var gizmondos = await _context.Gizmondos.FindAsync(id);

            if (gizmondos == null)
            {
                return NotFound();
            }

            return gizmondos;
        }

        // PUT: api/Gizmondos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGizmondos(int id, Gizmondos gizmondos)
        {
            if (id != gizmondos.Id)
            {
                return BadRequest();
            }

            _context.Entry(gizmondos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GizmondosExists(id))
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

        // POST: api/Gizmondos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gizmondos>> PostGizmondos(Gizmondos gizmondos)
        {

            if (_context.Gizmondos == null)
            {
                return NoContent();
            }
            _context.Gizmondos.Add(gizmondos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGizmondos", new { id = gizmondos.Id }, gizmondos);
        }

        // DELETE: api/Gizmondos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGizmondos(int id)
        {
            var gizmondos = await _context.Gizmondos.FindAsync(id);
            if (gizmondos == null)
            {
                return NotFound();
            }

            _context.Gizmondos.Remove(gizmondos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GizmondosExists(int id)
        {
            return _context.Gizmondos.Any(e => e.Id == id);
        }
    }
}
