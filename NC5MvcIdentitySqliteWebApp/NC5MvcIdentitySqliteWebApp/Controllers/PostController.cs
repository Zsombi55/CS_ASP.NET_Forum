using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NC5MvcIdentitySqliteWebApp.Data;
using NC5MvcIdentitySqliteWebApp.Models.Post;

namespace NC5MvcIdentitySqliteWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostViewModel.ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postViewModel = await _context.PostViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postViewModel == null)
            {
                return NotFound();
            }

            return View(postViewModel);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,CreatedAt,ModifiedAt,AuthorId,AuthorName,AuthorRating,AuthorImageUrl")] PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postViewModel);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postViewModel = await _context.PostViewModel.FindAsync(id);
            if (postViewModel == null)
            {
                return NotFound();
            }
            return View(postViewModel);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,CreatedAt,ModifiedAt,AuthorId,AuthorName,AuthorRating,AuthorImageUrl")] PostViewModel postViewModel)
        {
            if (id != postViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostViewModelExists(postViewModel.Id))
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
            return View(postViewModel);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postViewModel = await _context.PostViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postViewModel == null)
            {
                return NotFound();
            }

            return View(postViewModel);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postViewModel = await _context.PostViewModel.FindAsync(id);
            _context.PostViewModel.Remove(postViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostViewModelExists(int id)
        {
            return _context.PostViewModel.Any(e => e.Id == id);
        }
    }
}
