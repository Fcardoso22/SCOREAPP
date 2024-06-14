using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCORE.Data;
using SCORE.Models;

namespace SCORE.Controllers
{
    public class ExercicioUcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExercicioUcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExercicioUcs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExercicioUcs.Include(e => e.IdExercicioNavigation).Include(e => e.IdUcNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExercicioUcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExercicioUcs == null)
            {
                return NotFound();
            }

            var exercicioUc = await _context.ExercicioUcs
                .Include(e => e.IdExercicioNavigation)
                .Include(e => e.IdUcNavigation)
                .FirstOrDefaultAsync(m => m.IdExercicioUc == id);
            if (exercicioUc == null)
            {
                return NotFound();
            }

            return View(exercicioUc);
        }

        // GET: ExercicioUcs/Create
        public IActionResult Create()
        {
            ViewData["IdExercicio"] = new SelectList(_context.Exercicios, "IdExercicio", "Titulo");
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "Nome");
            return View();
        }

        // POST: ExercicioUcs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExercicioUc,IdExercicio,IdUc")] ExercicioUc exercicioUc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercicioUc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExercicio"] = new SelectList(_context.Exercicios, "IdExercicio", "Titulo", exercicioUc.IdExercicio);
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "Nome", exercicioUc.IdUc);
            return View(exercicioUc);
        }

        // GET: ExercicioUcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExercicioUcs == null)
            {
                return NotFound();
            }

            var exercicioUc = await _context.ExercicioUcs.FindAsync(id);
            if (exercicioUc == null)
            {
                return NotFound();
            }
            ViewData["IdExercicio"] = new SelectList(_context.Exercicios, "IdExercicio", "Titulo", exercicioUc.IdExercicio);
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "Nome", exercicioUc.IdUc);
            return View(exercicioUc);
        }

        // POST: ExercicioUcs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExercicioUc,IdExercicio,IdUc")] ExercicioUc exercicioUc)
        {
            if (id != exercicioUc.IdExercicioUc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercicioUc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioUcExists(exercicioUc.IdExercicioUc))
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
            ViewData["IdExercicio"] = new SelectList(_context.Exercicios, "IdExercicio", "Titulo", exercicioUc.IdExercicio);
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "Nome", exercicioUc.IdUc);
            return View(exercicioUc);
        }

        // GET: ExercicioUcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExercicioUcs == null)
            {
                return NotFound();
            }

            var exercicioUc = await _context.ExercicioUcs
                .Include(e => e.IdExercicioNavigation)
                .Include(e => e.IdUcNavigation)
                .FirstOrDefaultAsync(m => m.IdExercicioUc == id);
            if (exercicioUc == null)
            {
                return NotFound();
            }

            return View(exercicioUc);
        }

        // POST: ExercicioUcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExercicioUcs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExercicioUcs'  is null.");
            }
            var exercicioUc = await _context.ExercicioUcs.FindAsync(id);
            if (exercicioUc != null)
            {
                _context.ExercicioUcs.Remove(exercicioUc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioUcExists(int id)
        {
            return (_context.ExercicioUcs?.Any(e => e.IdExercicioUc == id)).GetValueOrDefault();
        }
    }
}
