using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCORE.Data;
using SCORE.Data.Migrations;
using SCORE.Models;

namespace SCORE.Controllers
{
    public class TurmaAlunosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TurmaAlunosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TurmaAlunos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TurmaAlunos.Include(t => t.IdTurmaNavigation).Include(t => t.NmecanograficoAlunoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }


       //[Authorize(Roles = "Docente, Admin")]
        public IActionResult ListarUtilizadores()
        {
            // Obtenha os dados das turmas e atribua à propriedade ViewBag.Turmas
            ViewBag.Turmas = _context.Turmas.ToList();

            var alunos = _userManager.GetUsersInRoleAsync("Aluno").Result;
            return View(alunos);
        }


        // GET: TurmaAlunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TurmaAlunos == null)
            {
                return NotFound();
            }

            var turmaAluno = await _context.TurmaAlunos
                .Include(t => t.IdTurmaNavigation)
                .Include(t => t.NmecanograficoAlunoNavigation)
                .FirstOrDefaultAsync(m => m.IdTurmaAluno == id);
            if (turmaAluno == null)
            {
                return NotFound();
            }

            return View(turmaAluno);
        }

        // GET: TurmaAlunos/Create
        public IActionResult Create()
        {
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma");
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno");
            return View();
        }

        // POST: TurmaAlunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurmaAluno,IdTurma,NmecanograficoAluno")] TurmaAluno turmaAluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmaAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", turmaAluno.IdTurma);
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno", turmaAluno.NmecanograficoAluno);
            return View(turmaAluno);
        }




        [HttpPost]
        public IActionResult InserirTurma(string alunoId)
        {
            // Lógica para inserir o aluno na turma

            // Redirecionar para a ação Details do TurmaUcsController com o ID do aluno
            return RedirectToAction("Details", "TurmaUcs", new { id = alunoId });
        }




        // GET: TurmaAlunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TurmaAlunos == null)
            {
                return NotFound();
            }

            var turmaAluno = await _context.TurmaAlunos.FindAsync(id);
            if (turmaAluno == null)
            {
                return NotFound();
            }
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", turmaAluno.IdTurma);
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno", turmaAluno.NmecanograficoAluno);
            return View(turmaAluno);
        }

        // POST: TurmaAlunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurmaAluno,IdTurma,NmecanograficoAluno")] TurmaAluno turmaAluno)
        {
            if (id != turmaAluno.IdTurmaAluno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmaAluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaAlunoExists(turmaAluno.IdTurmaAluno))
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
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", turmaAluno.IdTurma);
            ViewData["NmecanograficoAluno"] = new SelectList(_context.Alunos, "NmecanograficoAluno", "NmecanograficoAluno", turmaAluno.NmecanograficoAluno);
            return View(turmaAluno);
        }

        // GET: TurmaAlunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TurmaAlunos == null)
            {
                return NotFound();
            }

            var turmaAluno = await _context.TurmaAlunos
                .Include(t => t.IdTurmaNavigation)
                .Include(t => t.NmecanograficoAlunoNavigation)
                .FirstOrDefaultAsync(m => m.IdTurmaAluno == id);
            if (turmaAluno == null)
            {
                return NotFound();
            }

            return View(turmaAluno);
        }

        // POST: TurmaAlunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TurmaAlunos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TurmaAlunos'  is null.");
            }
            var turmaAluno = await _context.TurmaAlunos.FindAsync(id);
            if (turmaAluno != null)
            {
                _context.TurmaAlunos.Remove(turmaAluno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaAlunoExists(int id)
        {
          return (_context.TurmaAlunos?.Any(e => e.IdTurmaAluno == id)).GetValueOrDefault();
        }
    }
}
