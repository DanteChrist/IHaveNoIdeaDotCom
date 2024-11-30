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
    public class FashionIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FashionIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FashionIdeas
        public async Task<IActionResult> Index()
        {
            var ideas = await _context.FashionIdea
              .ToListAsync();
            return _context.FashionIdea != null ?
                        View(ideas) :
                        Problem("Entity set 'ApplicationDbContext.FashionIdea'  is null.");
        }

        // GET: FashionIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FashionIdea == null)
            {
                return NotFound();
            }

            var fashionIdea = await _context.FashionIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fashionIdea == null)
            {
                return NotFound();
            }

            return View(fashionIdea);
        }

        // GET: FashionIdeas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FashionIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] FashionIdea fashionIdea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fashionIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fashionIdea);
        }

        // GET: FashionIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FashionIdea == null)
            {
                return NotFound();
            }

            var fashionIdea = await _context.FashionIdea.FindAsync(id);
            if (fashionIdea == null)
            {
                return NotFound();
            }
            return View(fashionIdea);
        }

        // POST: FashionIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] FashionIdea fashionIdea)
        {
            if (id != fashionIdea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fashionIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FashionIdeaExists(fashionIdea.Id))
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
            return View(fashionIdea);
        }

        // GET: FashionIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FashionIdea == null)
            {
                return NotFound();
            }

            var fashionIdea = await _context.FashionIdea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fashionIdea == null)
            {
                return NotFound();
            }

            return View(fashionIdea);
        }

        // POST: FashionIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FashionIdea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FashionIdea'  is null.");
            }
            var fashionIdea = await _context.FashionIdea.FindAsync(id);
            if (fashionIdea != null)
            {
                _context.FashionIdea.Remove(fashionIdea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FashionIdeaExists(int id)
        {
          return (_context.FashionIdea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
