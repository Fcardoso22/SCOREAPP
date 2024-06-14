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
    public class ExerciciosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment _he;
        private readonly ILogger<ExerciciosController> _logger;

        public ExerciciosController(ApplicationDbContext context, IHostEnvironment e, ILogger<ExerciciosController> logger)
        {
            _context = context;
            _he = e;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Exercicios.Include(e => e.Opcoes);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Exercicio());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExercicio,Titulo,Descricao,Tipo,DataEntrega,Pergunta,Resposta")] Exercicio exercicio, [FromForm] List<Opcao> opcoes)
        {
            if (!ModelState.IsValid)
            {
                // Log the validation errors
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                }
                return View(exercicio);
            }

            _context.Add(exercicio);
            await _context.SaveChangesAsync();

            if (exercicio.Tipo == ExercicioTipo.Options && opcoes != null)
            {
                foreach (var opcao in opcoes)
                {
                    opcao.ExercicioId = exercicio.IdExercicio;
                    _context.Opcoes.Add(opcao);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios.Include(e => e.Opcoes).FirstOrDefaultAsync(e => e.IdExercicio == id);
            if (exercicio == null)
            {
                return NotFound();
            }
            return View(exercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExercicio,Titulo,Descricao,Tipo,DataEntrega,Pergunta,Resposta")] Exercicio exercicio, List<Opcao> opcoes)
        {
            if (id != exercicio.IdExercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var exercicioDb = await _context.Exercicios.Include(e => e.Opcoes).FirstOrDefaultAsync(e => e.IdExercicio == id);
                    if (exercicioDb == null)
                    {
                        return NotFound();
                    }

                    _context.Opcoes.RemoveRange(exercicioDb.Opcoes);
                    foreach (var opcao in opcoes)
                    {
                        opcao.ExercicioId = exercicio.IdExercicio;
                        _context.Opcoes.Add(opcao);
                    }

                    _context.Update(exercicioDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioExists(exercicio.IdExercicio))
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
            return View(exercicio);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios.Include(e => e.Opcoes).FirstOrDefaultAsync(m => m.IdExercicio == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exercicios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Exercicios' is null.");
            }
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio != null)
            {
                _context.Opcoes.RemoveRange(_context.Opcoes.Where(o => o.ExercicioId == id));
                _context.Exercicios.Remove(exercicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicios.Any(e => e.IdExercicio == id);
        }
    }
}
