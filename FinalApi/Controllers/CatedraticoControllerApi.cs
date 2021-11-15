using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalApi.Data;
using FinalApi.Models;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatedraticoControllerApi : ControllerBase
    {
        private readonly FinalApiContext _context;

        public CatedraticoControllerApi(FinalApiContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catedratico>>> GetCatedratico()
        {
            return await _context.Catedratico.ToListAsync();
        }

        // GET: api/CatedraticoControllerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catedratico>> GetCatedratico(int id)
        {
            var catedratico = await _context.Catedratico.FindAsync(id);

            if (catedratico == null)
            {
                return NotFound();
            }

            return catedratico;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatedratico(int id, Catedratico catedratico)
        {
            if (id != catedratico.Id)
            {
                return BadRequest();
            }

            _context.Entry(catedratico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatedraticoExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<Catedratico>> PostCatedratico(Catedratico catedratico)
        {
            _context.Catedratico.Add(catedratico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatedratico", new { id = catedratico.Id }, catedratico);
        }

        // DELETE: api/CatedraticoControllerApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Catedratico>> DeleteCatedratico(int id)
        {
            var catedratico = await _context.Catedratico.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            _context.Catedratico.Remove(catedratico);
            await _context.SaveChangesAsync();

            return catedratico;
        }

        private bool CatedraticoExists(int id)
        {
            return _context.Catedratico.Any(e => e.Id == id);
        }
    }
}
