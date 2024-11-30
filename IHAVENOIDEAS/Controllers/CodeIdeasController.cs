using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHAVENOIDEAS.Data;

namespace IHAVENOIDEAS.Controllers
{
    public class CodeIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CodeIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CodeIdeas
        public async Task<IActionResult> Index()
        {
            var ideas = await _context.CodeIdea
                .ToListAsync();
            return _context.CodeIdea != null ?
                        View(ideas) :
                        Problem("Entity set 'ApplicationDbContext.CodeIdea'  is null.");
        }

        // GET: CodeIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CodeIdea == null)
            {
                return NotFound();
            }

            var codeIdea = await _context.CodeIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeIdea == null)
            {
                return NotFound();
            }

            return View(codeIdea);
        }

        // GET: CodeIdeas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodeIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CodeIdea codeIdea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeIdea);
        }

        // GET: CodeIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CodeIdea == null)
            {
                return NotFound();
            }

            var codeIdea = await _context.CodeIdea.FindAsync(id);
            if (codeIdea == null)
            {
                return NotFound();
            }
            return View(codeIdea);
        }

        // POST: CodeIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] CodeIdea codeIdea)
        {
            if (id != codeIdea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeIdeaExists(codeIdea.Id))
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
            return View(codeIdea);
        }

        // GET: CodeIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CodeIdea == null)
            {
                return NotFound();
            }

            var codeIdea = await _context.CodeIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeIdea == null)
            {
                return NotFound();
            }

            return View(codeIdea);
        }

        // POST: CodeIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CodeIdea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CodeIdea'  is null.");
            }
            var codeIdea = await _context.CodeIdea.FindAsync(id);
            if (codeIdea != null)
            {
                _context.CodeIdea.Remove(codeIdea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeIdeaExists(int id)
        {
          return (_context.CodeIdea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
