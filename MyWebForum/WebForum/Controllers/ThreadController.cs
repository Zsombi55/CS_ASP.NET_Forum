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

		public ThreadController(IThreadEntity threadEntityService)
		{
			_threadEntityService = threadEntityService;
		}

		// GET : Thread
		/// <summary>
		/// Gets a "Microsoft.AspNetCore.Mvc.ViewResult" object that renders a View to the response.
		/// The MVC framework will look for a View called "Index" in a folder called "Thread".
		/// </summary>
		public IActionResult Index(int id)
		{
			var thread = _threadEntityService.GetById(id);

			var posts = BuildPostReplies(thread.Posts);

			var model = new ThreadIndexModel
			{
				Id = thread.Id,
				Title = thread.Title,
				CreatorId = thread.User.Id,
				CreatorName = thread.User.UserName,
				CreatorImageUrl = thread.User.ProfileImageUrl,
				CreatorRating = thread.User.Rating,
				CreatedAt = thread.CreatedAt,
				Content = thread.Content,
				Posts = posts
			};
				
			return View(model);
		}

		private IEnumerable<ReplyPostModel> BuildPostReplies(IEnumerable<PostEntity> posts)
		{
			return posts.Select(posts => new ReplyPostModel
			{
				Id = posts.Id,
				CreatorId = posts.User.Id,
				CreatorName = posts.User.UserName,
				CreatorImageUrl = posts.User.ProfileImageUrl,
				CreatorRating = posts.User.Rating,
				CreatedAt = posts.CreatedAt,
				ModifiedAt = posts.ModifiedAt,
				Content = posts.Content
			});
		}
	}
}
