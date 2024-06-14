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
    public class TurmaUcsController : Controller
    {


        private readonly ApplicationDbContext _context;

        public TurmaUcsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("TurmaUcs/Index/{Id}")]
        // GET: TurmaUcs
        public IActionResult Index(int Id)  //int Id
        {
            var applicationDbContext = _context.TurmaUcs.Include(t => t.IdTurmaNavigation).Include(t => t.IdUcNavigation);
            var final = applicationDbContext.Where(u => u.IdUc == Id);
            return View(final); //final
        }

        public IActionResult Index()  //int Id
        {
            var applicationDbContext = _context.TurmaUcs.Include(t => t.IdTurmaNavigation).Include(t => t.IdUcNavigation);
;
            return View(applicationDbContext); //final
        }


        //GET: TurmaUcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TurmaUcs == null)
            {
                return NotFound();
            }

            var turmaUc = await _context.TurmaUcs
                .Include(t => t.IdTurmaNavigation)
                .Include(t => t.IdUcNavigation)
                .FirstOrDefaultAsync(m => m.IdTurmaUc == id);
            if (turmaUc == null)
            {
                return NotFound();
            }

            return View(turmaUc);
        }

        // GET: TurmaUcs/Create
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma");
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "IdUc");
            return View();
        }

        // POST: TurmaUcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("IdTurmaUc,IdTurma,IdUc")] TurmaUc turmaUc)
        {
         
            
                _context.Add(turmaUc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
            //return View(turmaUc);
        }


        // GET: TurmaUcs/Edit/5
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TurmaUcs == null)
            {
                return NotFound();
            }

            var turmaUc = await _context.TurmaUcs.FindAsync(id);
            if (turmaUc == null)
            {
                return NotFound();
            }
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", turmaUc.IdTurma);
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "IdUc", turmaUc.IdUc);
            return View(turmaUc);
        }

        // POST: TurmaUcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurmaUc,IdTurma,IdUc")] TurmaUc turmaUc)
        {
            if (id != turmaUc.IdTurmaUc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmaUc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaUcExists(turmaUc.IdTurmaUc))
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
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", turmaUc.IdTurma);
            ViewData["IdUc"] = new SelectList(_context.Ucs, "IdUc", "IdUc", turmaUc.IdUc);
            return View(turmaUc);
        }

        // GET: TurmaUcs/Delete/5
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TurmaUcs == null)
            {
                return NotFound();
            }

            var turmaUc = await _context.TurmaUcs
                .Include(t => t.IdTurmaNavigation)
                .Include(t => t.IdUcNavigation)
                .FirstOrDefaultAsync(m => m.IdTurmaUc == id);
            if (turmaUc == null)
            {
                return NotFound();
            }

            return View(turmaUc);
        }

        // POST: TurmaUcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TurmaUcs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TurmaUcs'  is null.");
            }
            var turmaUc = await _context.TurmaUcs.FindAsync(id);
            if (turmaUc != null)
            {
                _context.TurmaUcs.Remove(turmaUc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaUcExists(int id)
        {
          return (_context.TurmaUcs?.Any(e => e.IdTurmaUc == id)).GetValueOrDefault();
        }
    }
}
