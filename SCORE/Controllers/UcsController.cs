using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCORE.Data;
using SCORE.Models;

namespace SCORE.Controllers
{
    [Authorize]
    public class UcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ucs
        public async Task<ActionResult> Index()
        {
            //var ucs = _context.Ucs.ToList();
            //return View(ucs);
            return _context.Ucs != null ?
                        View(await _context.Ucs.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Ucs'  is null.");
        }

        //public IActionResult Turmas(int Id)
        //{
        //    var uc = _context.Ucs.Include(u => u.TurmaUcs).FirstOrDefault(u=> u.IdUc== Id);
        //    return View(uc);
        //}

        // GET: Ucs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Ucs == null)
        //    {
        //        return NotFound();
        //    }

        //    var uc = await _context.Ucs
        //        .FirstOrDefaultAsync(m => m.IdUc == id);
        //    if (uc == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(uc);
        //}

        // GET: Ucs/Create


        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }


        // POST: Ucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
    
        
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("IdUc,Nome")] Uc uc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uc);
        }

        //[Authorize(Roles = "Admin")]
        // GET: Ucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ucs == null)
            {
                return NotFound();
            }

            var uc = await _context.Ucs.FindAsync(id);
            if (uc == null)
            {
                return NotFound();
            }
            return View(uc);
        }

        //[Authorize(Roles = "Admin")]
        // POST: Ucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUc,Nome")] Uc uc)
        {
            if (id != uc.IdUc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcExists(uc.IdUc))
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
            return View(uc);
        }

        // GET: Ucs/Delete/5
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ucs == null)
            {
                return NotFound();
            }

            var uc = await _context.Ucs
                .FirstOrDefaultAsync(m => m.IdUc == id);
            if (uc == null)
            {
                return NotFound();
            }

            return View(uc);
        }

        // POST: Ucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ucs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ucs'  is null.");
            }
            var uc = await _context.Ucs.FindAsync(id);
            if (uc != null)
            {
                _context.Ucs.Remove(uc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool UcExists(int id)
        {
          return (_context.Ucs?.Any(e => e.IdUc == id)).GetValueOrDefault();
        }
    }
}
