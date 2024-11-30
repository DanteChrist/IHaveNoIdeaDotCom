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
    public class PresentationIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresentationIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PresentationIdeas
        public async Task<IActionResult> Index()
        {
            var ideas = await _context.PresentationIdea
                .ToListAsync();
            return _context.PresentationIdea != null ?
                        View(ideas) :
                        Problem("Entity set 'ApplicationDbContext.PresentationIdea'  is null.");
        }

        // GET: PresentationIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PresentationIdea == null)
            {
                return NotFound();
            }

            var presentationIdea = await _context.PresentationIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentationIdea == null)
            {
                return NotFound();
            }

            return View(presentationIdea);
        }

        // GET: PresentationIdeas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PresentationIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PresentationIdea presentationIdea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentationIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presentationIdea);
        }

        // GET: PresentationIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PresentationIdea == null)
            {
                return NotFound();
            }

            var presentationIdea = await _context.PresentationIdea.FindAsync(id);
            if (presentationIdea == null)
            {
                return NotFound();
            }
            return View(presentationIdea);
        }

        // POST: PresentationIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] PresentationIdea presentationIdea)
        {
            if (id != presentationIdea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentationIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentationIdeaExists(presentationIdea.Id))
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
            return View(presentationIdea);
        }

        // GET: PresentationIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PresentationIdea == null)
            {
                return NotFound();
            }

            var presentationIdea = await _context.PresentationIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentationIdea == null)
            {
                return NotFound();
            }

            return View(presentationIdea);
        }

        // POST: PresentationIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PresentationIdea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PresentationIdea'  is null.");
            }
            var presentationIdea = await _context.PresentationIdea.FindAsync(id);
            if (presentationIdea != null)
            {
                _context.PresentationIdea.Remove(presentationIdea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentationIdeaExists(int id)
        {
          return (_context.PresentationIdea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
