using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Forum;
using WebForum.Models.Thread;

namespace WebForum.Controllers
{
	public class ForumController : Controller
	{
		private readonly IForumEntity _forumEntityService;
		private readonly IThreadEntity _threadEntityService;

		public ForumController(IForumEntity forumEntityService)
		{
			_forumEntityService = forumEntityService;
		}

		// GET : Forum
		/// <summary>
		/// Gets a "Microsoft.AspNetCore.Mvc.ViewResult" object that renders a View to the response.
		/// The MVC framework will look for a View called "Index" in a folder called "Forum".
		/// </summary>
		public IActionResult Index()
		{
			// FORCED casting like this does not work; it builds, but borks at runtime.
			//ForumListingModel forums = (ForumListingModel)_forumEntityService.GetAll()

			var forums = _forumEntityService.GetAll()
				.Select(forum => new ForumListingModel
				{
					Id = forum.Id,
					Title = forum.Title,
					Description = forum.Description
				});

			var model = new ForumIndexModel
			{
				// NO FORCED CASTING !
				//ForumList = (IEnumerable<ForumListingModel>)forums

				ForumList = forums
			};

			return View(model);
		}

		// GET : Forum
		/// <summary>
		/// Gets a Forum by its ID with all of its Threads for listing.
		/// </summary>
		/// <param name="id">Int: forum ID.</param>
		/// <returns>Object: a Forum's data, its Thread collection, and some of their data.</returns>
		public IActionResult Forum(int id)
		{
			var forum = _forumEntityService.GetById(id);
			//var threads = _threadEntityService.GetThreadsByForum(id);
			var threads = forum.Threads;

			var threadListings = threads.Select(thread => new ThreadListingModel
			{
				Id = thread.Id, // int
				Title = thread.Title,
				Status = thread.Status,
				CreatedAt = thread.CreatedAt.ToString(),
				ModifiedAt = thread.ModifiedAt.ToString(),
				PostCount = thread.Posts.Count(),
				AuthorId = thread.User.Id, // ApplicationUser : IdentityUser<string>
				AuthorName = thread.User.UserName,
				AuthorImageUrl = thread.User.ProfileImageUrl,
				CreatorRating = thread.User.Rating,
				Forum = BuildForumListing(thread)
			});

			var model = new ForumThreadsModel
			{
				Threads = threadListings,
				Forum = BuildForumListing(forum)
			};

			return View(model);
		}

		/// <summary>
		/// Overload.
		/// Collects the necessary data, generates then returns a Thread object for a Forum.
		/// </summary>
		/// <param name="thread">ThreadEntity object.</param>
		/// <returns>ForumEntity object: a forum based on the given thread.</returns>
		private ForumListingModel BuildForumListing(ThreadEntity thread)
		{
			var forum = thread.Forum;

			return BuildForumListing(forum);
			//return new ForumListingModel
			//{
			//	Id = forum.Id,
			//	Title = forum.Title,
			//	Description = forum.Description
			//};
		}

		/// <summary>
		/// Collects the necessary data, generates then returns a Forum object.
		/// </summary>
		/// <param name="forum">ForumEntity object.</param>
		/// <returns>ForumListingModel object: a forum.</returns>
		private ForumListingModel BuildForumListing(ForumEntity forum)
		{
			//var forum = thread.Forum;

			return new ForumListingModel
			{
				Id = forum.Id,
				Title = forum.Title,
				Description = forum.Description
			};
		}
	}
}
