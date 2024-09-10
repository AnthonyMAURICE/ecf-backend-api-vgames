﻿using System;
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
    public class PublishersController : ControllerBase
    {
        private readonly GizmondoContext _context;

        public PublishersController(GizmondoContext context)
        {
            _context = context;
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publishers>>> GetPublisher()
        {
            return await _context.Publishers.ToListAsync();
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publishers>> GetPublishers(int id)
        {
            var publishers = await _context.Publishers.FindAsync(id);

            if (publishers == null)
            {
                return NotFound();
            }

            return publishers;
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishers(int id, Publishers publishers)
        {
            if (id != publishers.Id)
            {
                return BadRequest();
            }

            _context.Entry(publishers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishersExists(id))
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

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publishers>> PostPublishers(Publishers publishers)
        {
            _context.Publishers.Add(publishers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublishers", new { id = publishers.Id }, publishers);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublishers(int id)
        {
            var publishers = await _context.Publishers.FindAsync(id);
            if (publishers == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publishers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublishersExists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }
    }
}
