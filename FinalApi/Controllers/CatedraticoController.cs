using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalApi.Data;
using FinalApi.Models;

namespace FinalApi
{
    public class CatedraticoController : Controller
    {
        private readonly FinalApiContext _context;

        public CatedraticoController(FinalApiContext context)
        {
            _context = context;
        }

        // GET: Catedratico
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catedratico.ToListAsync());
        }

        // GET: Catedratico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedratico = await _context.Catedratico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return View(catedratico);
        }

        // GET: Catedratico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catedratico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especialidad,Activo,Situacion")] Catedratico catedratico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catedratico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catedratico);
        }

        // GET: Catedratico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedratico = await _context.Catedratico.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }
            return View(catedratico);
        }

        // POST: Catedratico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especialidad,Activo,Situacion")] Catedratico catedratico)
        {
            if (id != catedratico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catedratico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatedraticoExists(catedratico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catedratico);
        }

        // GET: Catedratico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedratico = await _context.Catedratico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return View(catedratico);
        }

        // POST: Catedratico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catedratico = await _context.Catedratico.FindAsync(id);
            _context.Catedratico.Remove(catedratico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatedraticoExists(int id)
        {
            return _context.Catedratico.Any(e => e.Id == id);
        }
    }
}
