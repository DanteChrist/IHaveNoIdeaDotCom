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
    public class ArtIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtIdeas
        public async Task<IActionResult> Index()
        {
            var ideas = await _context.ArtIdea
                .ToListAsync();
              return _context.ArtIdea != null ? 
                          View(ideas) :
                          Problem("Entity set 'ApplicationDbContext.ArtIdea'  is null.");
        }

        // GET: ArtIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtIdea == null)
            {
                return NotFound();
            }

            var artIdea = await _context.ArtIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artIdea == null)
            {
                return NotFound();
            }

            return View(artIdea);
        }

        // GET: ArtIdeas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ArtIdea artIdea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artIdea);
        }

        // GET: ArtIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtIdea == null)
            {
                return NotFound();
            }

            var artIdea = await _context.ArtIdea.FindAsync(id);
            if (artIdea == null)
            {
                return NotFound();
            }
            return View(artIdea);
        }

        // POST: ArtIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ArtIdea artIdea)
        {
            if (id != artIdea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtIdeaExists(artIdea.Id))
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
            return View(artIdea);
        }

        // GET: ArtIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtIdea == null)
            {
                return NotFound();
            }

            var artIdea = await _context.ArtIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artIdea == null)
            {
                return NotFound();
            }

            return View(artIdea);
        }

        // POST: ArtIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtIdea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArtIdea'  is null.");
            }
            var artIdea = await _context.ArtIdea.FindAsync(id);
            if (artIdea != null)
            {
                _context.ArtIdea.Remove(artIdea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtIdeaExists(int id)
        {
          return (_context.ArtIdea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
