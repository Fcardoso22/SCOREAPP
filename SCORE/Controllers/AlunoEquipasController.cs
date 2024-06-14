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
    public class AlunoEquipasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunoEquipasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlunoEquipas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AlunoEquipas.Include(a => a.IdEquipaNavigation).Include(a => a.NmecanograficoAlunoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AlunoEquipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunoEquipas == null)
            {
                return NotFound();
            }

            var alunoEquipa = await _context.AlunoEquipas
                .Include(a => a.IdEquipaNavigation)
                .Include(a => a.NmecanograficoAlunoNavigation)
                .FirstOrDefaultAsync(m => m.IdAlunoEquipa == id);
            if (alunoEquipa == null)
            {
                return NotFound();
            }

            return View(alunoEquipa);
        }

        // GET: AlunoEquipas/Create
        public IActionResult Create()
        {
            ViewData["IdEquipa"] = new SelectList(_context.Equipas, "IdEquipa", "IdEquipa");
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno");
            return View();
        }

        // POST: AlunoEquipas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlunoEquipa,NmecanograficoAluno,IdEquipa,IdTurma")] AlunoEquipa alunoEquipa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoEquipa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipa"] = new SelectList(_context.Equipas, "IdEquipa", "IdEquipa", alunoEquipa.IdEquipa);
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno", alunoEquipa.NmecanograficoAluno);
            return View(alunoEquipa);
        }

        // GET: AlunoEquipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlunoEquipas == null)
            {
                return NotFound();
            }

            var alunoEquipa = await _context.AlunoEquipas.FindAsync(id);
            if (alunoEquipa == null)
            {
                return NotFound();
            }
            ViewData["IdEquipa"] = new SelectList(_context.Equipas, "IdEquipa", "IdEquipa", alunoEquipa.IdEquipa);
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno", alunoEquipa.NmecanograficoAluno);
            return View(alunoEquipa);
        }

        // POST: AlunoEquipas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlunoEquipa,NmecanograficoAluno,IdEquipa,IdTurma")] AlunoEquipa alunoEquipa)
        {
            if (id != alunoEquipa.IdAlunoEquipa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoEquipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoEquipaExists(alunoEquipa.IdAlunoEquipa))
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
            ViewData["IdEquipa"] = new SelectList(_context.Equipas, "IdEquipa", "IdEquipa", alunoEquipa.IdEquipa);
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno", alunoEquipa.NmecanograficoAluno);
            return View(alunoEquipa);
        }

        // GET: AlunoEquipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunoEquipas == null)
            {
                return NotFound();
            }

            var alunoEquipa = await _context.AlunoEquipas
                .Include(a => a.IdEquipaNavigation)
                .Include(a => a.NmecanograficoAlunoNavigation)
                .FirstOrDefaultAsync(m => m.IdAlunoEquipa == id);
            if (alunoEquipa == null)
            {
                return NotFound();
            }

            return View(alunoEquipa);
        }

        // POST: AlunoEquipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlunoEquipas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AlunoEquipas'  is null.");
            }
            var alunoEquipa = await _context.AlunoEquipas.FindAsync(id);
            if (alunoEquipa != null)
            {
                _context.AlunoEquipas.Remove(alunoEquipa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoEquipaExists(int id)
        {
          return (_context.AlunoEquipas?.Any(e => e.IdAlunoEquipa == id)).GetValueOrDefault();
        }
    }
}
