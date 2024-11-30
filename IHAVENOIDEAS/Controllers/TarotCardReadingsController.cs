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
    public class TarotCardReadingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarotCardReadingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TarotCardReadings
        public async Task<IActionResult> Index()
        {
            var reading = await _context.TarotCardReading
                .ToListAsync();
            return _context.TarotCardReading != null ?
                          View(reading):
                          Problem("Entity set 'ApplicationDbContext.TarotCardReading'  is null.");
        }

        // GET: TarotCardReadings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TarotCardReading == null)
            {
                return NotFound();
            }

            var tarotCardReading = await _context.TarotCardReading
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarotCardReading == null)
            {
                return NotFound();
            }

            return View(tarotCardReading);
        }

        // GET: TarotCardReadings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TarotCardReadings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardName,Meaning")] TarotCardReading tarotCardReading)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarotCardReading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarotCardReading);
        }

        // GET: TarotCardReadings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TarotCardReading == null)
            {
                return NotFound();
            }

            var tarotCardReading = await _context.TarotCardReading.FindAsync(id);
            if (tarotCardReading == null)
            {
                return NotFound();
            }
            return View(tarotCardReading);
        }

        // POST: TarotCardReadings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardName,Meaning")] TarotCardReading tarotCardReading)
        {
            if (id != tarotCardReading.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarotCardReading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarotCardReadingExists(tarotCardReading.Id))
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
            return View(tarotCardReading);
        }

        // GET: TarotCardReadings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TarotCardReading == null)
            {
                return NotFound();
            }

            var tarotCardReading = await _context.TarotCardReading
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarotCardReading == null)
            {
                return NotFound();
            }

            return View(tarotCardReading);
        }

        // POST: TarotCardReadings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TarotCardReading == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TarotCardReading'  is null.");
            }
            var tarotCardReading = await _context.TarotCardReading.FindAsync(id);
            if (tarotCardReading != null)
            {
                _context.TarotCardReading.Remove(tarotCardReading);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarotCardReadingExists(int id)
        {
          return (_context.TarotCardReading?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
