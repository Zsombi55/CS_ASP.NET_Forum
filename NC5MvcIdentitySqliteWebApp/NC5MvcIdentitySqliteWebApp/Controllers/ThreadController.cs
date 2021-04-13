using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NC5MvcIdentitySqliteWebApp.Data;
using NC5MvcIdentitySqliteWebApp.Models.Thread;

namespace NC5MvcIdentitySqliteWebApp.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThreadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Thread
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThreadViewModel.ToListAsync());
        }

        // GET: Thread/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threadViewModel = await _context.ThreadViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threadViewModel == null)
            {
                return NotFound();
            }

            return View(threadViewModel);
        }

        // GET: Thread/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thread/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatedAt,ModifiedAt,AuthorId,AuthorName,AuthorImageUrl,AuthorRating,PostCount")] ThreadViewModel threadViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threadViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(threadViewModel);
        }

        // GET: Thread/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threadViewModel = await _context.ThreadViewModel.FindAsync(id);
            if (threadViewModel == null)
            {
                return NotFound();
            }
            return View(threadViewModel);
        }

        // POST: Thread/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatedAt,ModifiedAt,AuthorId,AuthorName,AuthorImageUrl,AuthorRating,PostCount")] ThreadViewModel threadViewModel)
        {
            if (id != threadViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threadViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreadViewModelExists(threadViewModel.Id))
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
            return View(threadViewModel);
        }

        // GET: Thread/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threadViewModel = await _context.ThreadViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threadViewModel == null)
            {
                return NotFound();
            }

            return View(threadViewModel);
        }

        // POST: Thread/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threadViewModel = await _context.ThreadViewModel.FindAsync(id);
            _context.ThreadViewModel.Remove(threadViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreadViewModelExists(int id)
        {
            return _context.ThreadViewModel.Any(e => e.Id == id);
        }
    }
}
