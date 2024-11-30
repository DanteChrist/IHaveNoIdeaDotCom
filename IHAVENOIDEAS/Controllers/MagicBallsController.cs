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
    public class MagicBallsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MagicBallsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MagicBalls
        public async Task<IActionResult> Index()
        {

            var ideas = await _context.MagicBall
                .ToListAsync();
            return _context.MagicBall != null ?
                        View(ideas) :
                        Problem("Entity set 'ApplicationDbContext.MagicBall'  is null.");
        }

        // GET: MagicBalls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MagicBall == null)
            {
                return NotFound();
            }

            var magicBall = await _context.MagicBall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magicBall == null)
            {
                return NotFound();
            }

            return View(magicBall);
        }

        // GET: MagicBalls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MagicBalls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] MagicBall magicBall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magicBall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magicBall);
        }

        // GET: MagicBalls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MagicBall == null)
            {
                return NotFound();
            }

            var magicBall = await _context.MagicBall.FindAsync(id);
            if (magicBall == null)
            {
                return NotFound();
            }
            return View(magicBall);
        }

        // POST: MagicBalls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] MagicBall magicBall)
        {
            if (id != magicBall.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magicBall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagicBallExists(magicBall.Id))
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
            return View(magicBall);
        }

        // GET: MagicBalls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MagicBall == null)
            {
                return NotFound();
            }

            var magicBall = await _context.MagicBall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magicBall == null)
            {
                return NotFound();
            }

            return View(magicBall);
        }

        // POST: MagicBalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MagicBall == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MagicBall'  is null.");
            }
            var magicBall = await _context.MagicBall.FindAsync(id);
            if (magicBall != null)
            {
                _context.MagicBall.Remove(magicBall);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagicBallExists(int id)
        {
          return (_context.MagicBall?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
