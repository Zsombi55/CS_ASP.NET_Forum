using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NC5MvcIdentitySqliteWebApp.Data;
using NC5MvcIdentitySqliteWebApp.Models.Board;

namespace NC5MvcIdentitySqliteWebApp.Controllers
{
    public class BoardViewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardViewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoardView
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoardViewModel.ToListAsync());
        }

        // GET: BoardView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardViewModel = await _context.BoardViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardViewModel == null)
            {
                return NotFound();
            }

            return View(boardViewModel);
        }

        // GET: BoardView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardView/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] BoardViewModel boardViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardViewModel);
        }

        // GET: BoardView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardViewModel = await _context.BoardViewModel.FindAsync(id);
            if (boardViewModel == null)
            {
                return NotFound();
            }
            return View(boardViewModel);
        }

        // POST: BoardView/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] BoardViewModel boardViewModel)
        {
            if (id != boardViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardViewModelExists(boardViewModel.Id))
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
            return View(boardViewModel);
        }

        // GET: BoardView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardViewModel = await _context.BoardViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardViewModel == null)
            {
                return NotFound();
            }

            return View(boardViewModel);
        }

        // POST: BoardView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boardViewModel = await _context.BoardViewModel.FindAsync(id);
            _context.BoardViewModel.Remove(boardViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardViewModelExists(int id)
        {
            return _context.BoardViewModel.Any(e => e.Id == id);
        }
    }
}
