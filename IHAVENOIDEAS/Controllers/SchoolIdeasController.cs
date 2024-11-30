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
    public class SchoolIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchoolIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SchoolIdeas
        public async Task<IActionResult> Index()
        {
             var ideas = await _context.SchoolIdea
                .ToListAsync();
            return _context.SchoolIdea != null ?
                   View(ideas) :
                   Problem("Entity set 'ApplicationDbContext.SchoolIdea'  is null.");
        }

        // GET: SchoolIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolIdea == null)
            {
                return NotFound();
            }

            var schoolIdea = await _context.SchoolIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolIdea == null)
            {
                return NotFound();
            }

            return View(schoolIdea);
        }

        // GET: SchoolIdeas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] SchoolIdea schoolIdea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolIdea);
        }

        // GET: SchoolIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolIdea == null)
            {
                return NotFound();
            }

            var schoolIdea = await _context.SchoolIdea.FindAsync(id);
            if (schoolIdea == null)
            {
                return NotFound();
            }
            return View(schoolIdea);
        }

        // POST: SchoolIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] SchoolIdea schoolIdea)
        {
            if (id != schoolIdea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolIdeaExists(schoolIdea.Id))
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
            return View(schoolIdea);
        }

        // GET: SchoolIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolIdea == null)
            {
                return NotFound();
            }

            var schoolIdea = await _context.SchoolIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolIdea == null)
            {
                return NotFound();
            }

            return View(schoolIdea);
        }

        // POST: SchoolIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolIdea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SchoolIdea'  is null.");
            }
            var schoolIdea = await _context.SchoolIdea.FindAsync(id);
            if (schoolIdea != null)
            {
                _context.SchoolIdea.Remove(schoolIdea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolIdeaExists(int id)
        {
          return (_context.SchoolIdea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
