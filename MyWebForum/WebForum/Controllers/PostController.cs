using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
	public class PostController : Controller
	{
		private readonly IThreadEntity _threadEntityService;
		private readonly IApplicationUser _appUserService;
		private readonly UserManager<ApplicationUser> _userManager;

		public PostController(IThreadEntity threadEntityService, IApplicationUser appUserService,
			UserManager<ApplicationUser> userManager)
		{
			_threadEntityService = threadEntityService;
			_appUserService = appUserService;
			_userManager = userManager;
		}

		/// <summary>
		/// Adds a new "Post" object to the ID-d parent "Thread" object.
		/// </summary>
		/// <param name="id">Integer: the ID of the parent "Thread" object.</param>
		/// <returns>View model data: for showing the post-creation page.</returns>
		public async Task<IActionResult> Create(int id)
		{
			var thread = _threadEntityService.GetById(id);

			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var model = new NewPostModel{
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

		/// <summary>
		/// Sets/ Posts user-input into a view model then pushes that into the DB.
		/// A form method type post, triggers this; so it doesn't handle it like a typical GET request.
		/// [bad explanation]
		/// </summary>
		/// <param name="model">NewPostModel obj.; returned by the "Create" function above.</param>
		/// <returns>An action: set view to the newly created Post's Thread Index by its ID.</returns>
		[HttpPost]
		public async Task<IActionResult> AddPost(NewPostModel model)
		{
			var userId = _userManager.GetUserId(User);
			var user = await _userManager.FindByIdAsync(userId);

			var post = BuildPost(model, user);

			await _threadEntityService.AddPost(post);

			await _appUserService.UpdateRating(userId, typeof(PostEntity));

			return RedirectToAction("Index", "Thread", new {id = model.ThreadId });
		}

		/// <summary>
		/// Gets user input into a model for making a new Post.
		/// </summary>
		/// <param name="model">NewPostModel obj.; what is needed at least to make a new one.</param>
		/// <param name="user">Current user.</param>
		/// <returns>Object: a new PostEntity based on the NewPostModel data template.</returns>
		private PostEntity BuildPost(NewPostModel model, ApplicationUser user)
		{
			var thread = _threadEntityService.GetById(model.ThreadId);

			return new PostEntity{
				Thread = thread,
				Content = model.Content,
				CreatedAt = DateTime.Now,
				//ModifiedAt = DateTime.Now,
				User = user
			};
		}
	}
}
