using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaAWSCubosFMB.Data;
using PracticaAWSCubosFMB.Models;

namespace PracticaAWSCubosFMB.Controllers
{
    public class CuboesController : Controller
    {
        private readonly CubosContext _context;

        public CuboesController(CubosContext context)
        {
            _context = context;
        }

        // GET: Cuboes
        public async Task<IActionResult> Index()
        {
            return _context.Cubos != null ?
                        View(await _context.Cubos.ToListAsync()) :
                        Problem("Entity set 'CubosContext.Cubos'  is null.");
        }

        // GET: Cuboes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cubos == null)
            {
                return NotFound();
            }

            var cubo = await _context.Cubos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cubo == null)
            {
                return NotFound();
            }

            return View(cubo);
        }

        // GET: Cuboes/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task<int> GetMaxCuboAsync()
        {
            return await _context.Cubos.MaxAsync(x => x.Id) + 1;
        }

        // POST: Cuboes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Marca,Imagen,Precio")] Cubo cubo)
        {
            if (ModelState.IsValid)
            {
                cubo.Id = await GetMaxCuboAsync();
                _context.Add(cubo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cubo);
        }

        // GET: Cuboes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cubos == null)
            {
                return NotFound();
            }

            var cubo = await _context.Cubos.FindAsync(id);
            if (cubo == null)
            {
                return NotFound();
            }
            return View(cubo);
        }

        // POST: Cuboes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Marca,Imagen,Precio")] Cubo cubo)
        {
            if (id != cubo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cubo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuboExists(cubo.Id))
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
            return View(cubo);
        }

        // GET: Cuboes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cubos == null)
            {
                return NotFound();
            }

            var cubo = await _context.Cubos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cubo == null)
            {
                return NotFound();
            }

            return View(cubo);
        }

        // POST: Cuboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cubos == null)
            {
                return Problem("Entity set 'CubosContext.Cubos'  is null.");
            }
            var cubo = await _context.Cubos.FindAsync(id);
            if (cubo != null)
            {
                _context.Cubos.Remove(cubo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuboExists(int id)
        {
            return (_context.Cubos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
