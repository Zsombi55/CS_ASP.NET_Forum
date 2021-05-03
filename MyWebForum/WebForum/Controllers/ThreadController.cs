﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Forum;
using WebForum.Models.Post;
using WebForum.Models.Thread;

namespace WebForum.Controllers
{
	public class ThreadController : Controller
	{
		private readonly IThreadEntity _threadEntityService;
		private readonly IForumEntity _forumEntityService;

		private static UserManager<ApplicationUser> _userManager;
		// provides the APIs for interacting with the Users in the data-storage.

		public ThreadController(IThreadEntity threadEntityService, IForumEntity forumEntityService,
			UserManager<ApplicationUser> userManager)
		{
			_threadEntityService = threadEntityService;
			_forumEntityService = forumEntityService;
			_userManager = userManager;
		}
		// TODO: if User IS NOT authen. & author. thread editing and cretion should not even be offered.

		// GET : Thread
		/// <summary>
		/// Gets a "Microsoft.AspNetCore.Mvc.ViewResult" object that renders a View to the response.
		/// The MVC framework will look for a View called "Index" in a folder called "Thread".
		/// </summary>
		/// <param name="id">Int: a forum's ID.</param>
		/// <returns>ThreadIndexModel object: a thread and its posts.</returns>
		public IActionResult Index(int id)
		{
			var thread = _threadEntityService.GetById(id);

			var posts = BuildThreadReplies(thread.Posts);

			var model = new ThreadIndexModel
			{
				Id = thread.Id,
				Title = thread.Title,
				Content = thread.Content,
				CreatedAt = thread.CreatedAt,
				ModifiedAt = thread.ModifiedAt,
				AuthorId = thread.User.Id,
				AuthorName = thread.User.UserName,
				AuthorImageUrl = thread.User.ProfileImageUrl,
				AuthorRating = thread.User.Rating,
				Posts = posts
			};
				
			return View(model);
		}

		// POST : Thread
		/// <summary>
		/// Gets the existing data to which later the User-entered data can be connected to.
		/// [bad explanation, this basically gets references to where the new thread obj. will belong to]
		/// </summary>
		/// <param name="id">Integer: Forum obj. ID parameter.</param>
		/// <returns>NewThreadModel object: basic new thread creation data.</returns>
		public IActionResult Create(int id)
		{
			var forum = _forumEntityService.GetById(id);

			var model = new NewThreadModel
			{
				ForumId = forum.Id,
				ForumName = forum.Title,
				AuthorName = User.Identity.Name
				// the User obj. from the current http context,
				// so: whoever is logged in & using the Thread Creation form is the User.
			};

			return View(model);
		}

		/// <summary>
		/// Sets/ Posts user-input into a view model then pushes that into the DB.
		/// A form method type post, triggers this; so it doesn't handle it like a typical GET request.
		/// [bad explanation]
		/// </summary>
		/// <param name="model">NewThreadModel obj.; returned by the "Create" function above.</param>
		/// <returns>An action: set view to the newly created Thread Index by its ID.</returns>
		[HttpPost]
		public async Task<IActionResult> AddThread(NewThreadModel model)
		{
			var userId = _userManager.GetUserId(User);
			//var user = _userManager.FindByIdAsync(userId).Result;
			var user = await _userManager.FindByIdAsync(userId);

			var thread = BuildThread(model, user);

			//await _threadEntityService.Create(thread);
			// Block current thread, wait for task completion - NOTE: bad workaround, shoud use "await".
			_threadEntityService.Create(thread).Wait();

			// TODO: add user rating manager

			return RedirectToAction("Index", "Thread", new { id = thread.Id });
		}

		/// <summary>
		/// Gets user input into a model for making a new Thread.
		/// </summary>
		/// <param name="model">NewThreadModel obj.; what is needed at least to make a new one.</param>
		/// <param name="user">Current user.</param>
		/// <returns>Object: a new ThreadEntity based on the NewThreadModel data template.</returns>
		private ThreadEntity BuildThread(NewThreadModel model, ApplicationUser user)
		{
			var forum = _forumEntityService.GetById(model.ForumId);

			return new ThreadEntity
			{
				Title = model.Title,
				Content = model.Content,
				CreatedAt = DateTime.Now,
				User = user,
				Forum = forum
			};
		}

		/// <summary>
		/// Gets all posts of a Thread as a collection.
		/// </summary>
		/// <param name="posts">PostEntity object.</param>
		/// <returns>Collection object: a thread's posts.</returns>
		private IEnumerable<PostModel> BuildThreadReplies(IEnumerable<PostEntity> posts)
		{
			return posts.Select(post => new PostModel
			{
				Id = post.Id,
				Content = post.Content,
				CreatedAt = post.CreatedAt,
				ModifiedAt = post.ModifiedAt,
				AuthorId = post.User.Id,
				AuthorName = post.User.UserName,
				AuthorImageUrl = post.User.ProfileImageUrl,
				AuthorRating = post.User.Rating
			});
		}

		// How would it be different from "Index(int id)" above ??
		public IActionResult GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
