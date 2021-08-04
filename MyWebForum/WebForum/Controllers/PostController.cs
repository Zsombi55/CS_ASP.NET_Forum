using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Post;

namespace WebForum.Controllers
{
	public class PostController : Controller
	{
		private readonly IThreadEntity _threadService;
		private readonly UserManager<ApplicationUser> _userManager;

		protected PostController(IThreadEntity threadService)
		{
			_threadService = threadService;
		}

		public async Task<IActionResult> Create(int id)
		{
			var thread = _threadService.GetById(id);

			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var model = new PostModel{
				ThreadContent = thread.Content,
				ThreadTitle = thread.Title,
				ThreadId = thread.Id,

				AuthorId = user.Id,
				AuthorName = User.Identity.Name,
				AuthorImageUrl = user.ProfileImageUrl,
				AuthorRating = user.Rating,
				IsAuthorAdmin = User.IsInRole("Admin"),

				ForumId = thread.Forum.Id,
				ForumTitle = thread.Forum.Title,
												
				CreatedAt = DateTime.Now
			};

			return View(model);
		}
	}
}
