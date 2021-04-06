using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public ThreadController(IThreadEntity threadEntityService)
		{
			_threadEntityService = threadEntityService;
		}

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
