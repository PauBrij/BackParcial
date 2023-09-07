using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialVeterinaria.Models;

namespace ParcialVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mascota2Controller : ControllerBase
    {
        private readonly ParcialVetContext _context;

        public Mascota2Controller(ParcialVetContext context)
        {
            _context = context;
        }

        // GET: api/Mascota2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota2>>> GetMascota2s()
        {
          if (_context.Mascota2s == null)
          {
              return NotFound();
          }
            return await _context.Mascota2s.ToListAsync();
        }

        // GET: api/Mascota2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota2>> GetMascota2(int id)
        {
          if (_context.Mascota2s == null)
          {
              return NotFound();
          }
            var mascota2 = await _context.Mascota2s.FindAsync(id);

            if (mascota2 == null)
            {
                return NotFound();
            }

            return mascota2;
        }

        // PUT: api/Mascota2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota2(int id, Mascota2 mascota2)
        {
            if (id != mascota2.IdMascota)
            {
                return BadRequest();
            }

            _context.Entry(mascota2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Mascota2Exists(id))
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

        // POST: api/Mascota2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mascota2>> PostMascota2(Mascota2 mascota2)
        {
          if (_context.Mascota2s == null)
          {
              return Problem("Entity set 'ParcialVetContext.Mascota2s'  is null.");
          }
            _context.Mascota2s.Add(mascota2);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Mascota2Exists(mascota2.IdMascota))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMascota2", new { id = mascota2.IdMascota }, mascota2);
        }

        // DELETE: api/Mascota2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota2(int id)
        {
            if (_context.Mascota2s == null)
            {
                return NotFound();
            }
            var mascota2 = await _context.Mascota2s.FindAsync(id);
            if (mascota2 == null)
            {
                return NotFound();
            }

            _context.Mascota2s.Remove(mascota2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Mascota2Exists(int id)
        {
            return (_context.Mascota2s?.Any(e => e.IdMascota == id)).GetValueOrDefault();
        }
    }
}
