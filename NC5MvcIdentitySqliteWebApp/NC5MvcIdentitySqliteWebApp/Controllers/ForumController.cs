using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NC5MvcIdentitySqliteWebApp.Data;
using NC5MvcIdentitySqliteWebApp.Models.Forum;

namespace NC5MvcIdentitySqliteWebApp.Controllers
{
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Forum
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForumViewModel.ToListAsync());
        }

        // GET: Forum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumViewModel = await _context.ForumViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumViewModel == null)
            {
                return NotFound();
            }

            return View(forumViewModel);
        }

        // GET: Forum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] ForumViewModel forumViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumViewModel);
        }

        // GET: Forum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumViewModel = await _context.ForumViewModel.FindAsync(id);
            if (forumViewModel == null)
            {
                return NotFound();
            }
            return View(forumViewModel);
        }

        // POST: Forum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] ForumViewModel forumViewModel)
        {
            if (id != forumViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumViewModelExists(forumViewModel.Id))
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
            return View(forumViewModel);
        }

        // GET: Forum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumViewModel = await _context.ForumViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumViewModel == null)
            {
                return NotFound();
            }

            return View(forumViewModel);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumViewModel = await _context.ForumViewModel.FindAsync(id);
            _context.ForumViewModel.Remove(forumViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumViewModelExists(int id)
        {
            return _context.ForumViewModel.Any(e => e.Id == id);
        }
    }
}
