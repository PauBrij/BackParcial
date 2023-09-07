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
    public class Cliente2Controller : ControllerBase
    {
        private readonly ParcialVetContext _context;

        public Cliente2Controller(ParcialVetContext context)
        {
            _context = context;
        }

        // GET: api/Cliente2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente2>>> GetCliente2s()
        {
          if (_context.Cliente2s == null)
          {
              return NotFound();
          }
            return await _context.Cliente2s.ToListAsync();
        }

        // GET: api/Cliente2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente2>> GetCliente2(int id)
        {
          if (_context.Cliente2s == null)
          {
              return NotFound();
          }
            var cliente2 = await _context.Cliente2s.FindAsync(id);

            if (cliente2 == null)
            {
                return NotFound();
            }

            return cliente2;
        }

        // PUT: api/Cliente2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente2(int id, Cliente2 cliente2)
        {
            if (id != cliente2.Cedula)
            {
                return BadRequest();
            }

            _context.Entry(cliente2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cliente2Exists(id))
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

        // POST: api/Cliente2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente2>> PostCliente2(Cliente2 cliente2)
        {
          if (_context.Cliente2s == null)
          {
              return Problem("Entity set 'ParcialVetContext.Cliente2s'  is null.");
          }
            _context.Cliente2s.Add(cliente2);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Cliente2Exists(cliente2.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente2", new { id = cliente2.Cedula }, cliente2);
        }

        // DELETE: api/Cliente2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente2(int id)
        {
            if (_context.Cliente2s == null)
            {
                return NotFound();
            }
            var cliente2 = await _context.Cliente2s.FindAsync(id);
            if (cliente2 == null)
            {
                return NotFound();
            }

            _context.Cliente2s.Remove(cliente2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cliente2Exists(int id)
        {
            return (_context.Cliente2s?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
