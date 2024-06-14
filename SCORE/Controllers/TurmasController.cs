using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SCORE.Data;
using SCORE.Data.Migrations;
using SCORE.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace SCORE.Controllers
{
    //public class TurmaUCViewModel
    //{
    //    public int IdTurma { get; set; } = 0;
    //    public string? NomeTurma { get; set; } 
    //    public int IdUC { get; set; } = 0;
    //    public string? NomeUC { get; set; }
    //}

    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
              return _context.Turmas != null ? 
                          View(await _context.Turmas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Turmas'  is null.");
        }


        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .FirstOrDefaultAsync(m => m.IdTurma == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurma,Numero")] Turma turma)
        {

                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "TurmaUcs");
                //return RedirectToAction(nameof(Index));
            //return View(turma);
        }



    // GET: Turmas/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> Edit(int id, [Bind("IdTurma,Numero")] Turma turma)
        {
            if (id != turma.IdTurma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.IdTurma))
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
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .FirstOrDefaultAsync(m => m.IdTurma == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turmas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Turmas'  is null.");
            }
            var turma = await _context.Turmas.FindAsync(id);
            if (turma != null)
            {
                _context.Turmas.Remove(turma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //public async Task<IActionResult> CreateTurmaUc(TurmaUCViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Cria uma nova instância da TurmaUc com a turma e UC selecionadas
        //        var turmaUc = new TurmaUc
        //        {
        //            IdTurma = viewModel.IdTurma,
        //            IdUc = viewModel.IdUC
        //        };

        //        // Adiciona a nova TurmaUc ao contexto e salva as mudanças no banco de dados
        //        _context.Add(turmaUc);
        //        await _context.SaveChangesAsync();

        //        // Redireciona para a página principal
        //        return RedirectToAction(nameof(Index));
           // }

            // Se houver um erro, retorna a View com os dados do ViewModel e a lista de Ucs
        //    var ucList = _context.Ucs.ToList();
        //    var selectList = new SelectList(ucList, "IdUc", "Nome");
        //    ViewData["UcList"] = selectList;
        //    return View(viewModel);
        //}

        private bool TurmaExists(int id)
        {
          return (_context.Turmas?.Any(e => e.IdTurma == id)).GetValueOrDefault();
        }
    }
}
