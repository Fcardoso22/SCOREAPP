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
using SCORE.Models;

namespace SCORE.Controllers
{
    public class CampeonatosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;



        public CampeonatosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Campeonatos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Campeonatos.Include(c => c.IdTurmaNavigation).Include(c => c.IdUcNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Campeonatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campeonatos == null)
            {
                return NotFound();
            }

            var campeonato = await _context.Campeonatos
                .Include(c => c.IdTurmaNavigation)
                .Include(c => c.IdUcNavigation)
                .FirstOrDefaultAsync(m => m.IdCampeonato == id);
            if (campeonato == null)
            {
                return NotFound();
            }

            return View(campeonato);
        }

        // GET: Campeonatos/Create
        public IActionResult Create()
        {
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma");
            ViewData["IdUC"] = new SelectList(_context.Ucs, "IdUc", "IdUc");
            return View();
        }

        // POST: Campeonatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCampeonato,Terminado,IdTurma,IdUC")] Campeonato campeonato)
        {

                _context.Add(campeonato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", campeonato.IdTurma);
            ViewData["IdUC"] = new SelectList(_context.Ucs, "IdUc", "IdUc", campeonato.IdUC);

        }

        // GET: Campeonatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campeonatos == null)
            {
                return NotFound();
            }

            var campeonato = await _context.Campeonatos.FindAsync(id);
            if (campeonato == null)
            {
                return NotFound();
            }
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", campeonato.IdTurma);
            ViewData["IdUC"] = new SelectList(_context.Ucs, "IdUc", "IdUc", campeonato.IdUC);
            return View(campeonato);
        }

        private string GetNomeAlunoAleatorio(List<TabelaClassificatoriaItem> tabelaClassificatoria, string nomeAlunoAtual)
        {
            var nomesDisponiveis = tabelaClassificatoria.Where(a => a.NomeAluno != nomeAlunoAtual).Select(a => a.NomeAluno).ToList();
            var random = new Random();
            var index = random.Next(nomesDisponiveis.Count);
            return nomesDisponiveis[index];
        }


        //[Authorize (Roles = "Aluno, Docente")]
        public IActionResult TabelaClassificatoria()
        {
            var alunos = _userManager.GetUsersInRoleAsync("Aluno").Result;

            var tabelaClassificatoria = new List<TabelaClassificatoriaItem>();

            foreach (var aluno in alunos)
            {
                var item = new TabelaClassificatoriaItem
                {
                    NomeAluno = aluno.UserName,
                    Pontuacao = 0
                };

                tabelaClassificatoria.Add(item);
            }

            tabelaClassificatoria = tabelaClassificatoria.OrderByDescending(item => item.Pontuacao).ToList();

            ViewBag.GetNomeAlunoAleatorio = new Func<List<TabelaClassificatoriaItem>, string, string>(GetNomeAlunoAleatorio);

            return View(tabelaClassificatoria);
        }




        // POST: Campeonatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCampeonato,Terminado,IdTurma,IdUC")] Campeonato campeonato)
        {
            if (id != campeonato.IdCampeonato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campeonato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampeonatoExists(campeonato.IdCampeonato))
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
            ViewData["IdTurma"] = new SelectList(_context.Turmas, "IdTurma", "IdTurma", campeonato.IdTurma);
            ViewData["IdUC"] = new SelectList(_context.Ucs, "IdUc", "IdUc", campeonato.IdUC);
            return View(campeonato);
        }

        // GET: Campeonatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campeonatos == null)
            {
                return NotFound();
            }

            var campeonato = await _context.Campeonatos
                .Include(c => c.IdTurmaNavigation)
                .Include(c => c.IdUcNavigation)
                .FirstOrDefaultAsync(m => m.IdCampeonato == id);
            if (campeonato == null)
            {
                return NotFound();
            }

            return View(campeonato);
        }

        // POST: Campeonatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campeonatos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Campeonatos'  is null.");
            }
            var campeonato = await _context.Campeonatos.FindAsync(id);
            if (campeonato != null)
            {
                _context.Campeonatos.Remove(campeonato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampeonatoExists(int id)
        {
          return (_context.Campeonatos?.Any(e => e.IdCampeonato == id)).GetValueOrDefault();
        }
    }
}
