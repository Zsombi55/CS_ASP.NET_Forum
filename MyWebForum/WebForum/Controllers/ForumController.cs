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
			// FORCED casting like this does not work; it builds, but it borks at runtime.
			//ForumListingModel forums = (ForumListingModel)_forumEntityService.GetAll()

			var forums = _forumEntityService.GetAll()
				.Select(forum => new ForumListingModel {
					Id = forum.Id,
					Title = forum.Title,
					Description = forum.Description,
					Status = forum.Status
				});

			var model = new ForumIndexModel
			{
				// NO FORCED CASTING !
				//ForumList = (IEnumerable<ForumListingModel>)forums

				ForumList = forums
			};

			return View(model);
		}

		// GET : Topic / a Forum
		/// <summary>
		/// Gets a Forum by its ID including all of its Threads.
		/// </summary>
		/// <param name="id">Int: forum ID.</param>
		/// <returns>Object: a Forum's data, its Thread collection, and some of their data.</returns>
		public IActionResult Topic(int id)
		{
			var forum = _forumEntityService.GetById(id);
			//var thread = _threadEntityService.GetThreadsByForum(id);
			var thread = forum.Threads;

			// Identity-/ Application-User ID : Microsoft.AspNetCore.Identity.IdentityUser<string>.Id
			var threadListings = thread.Select(thread => new ThreadListingModel
			{
				Id = thread.Id,
				Title = thread.Title,
				Status = thread.Status,
				CreatorId = thread.User.Id,
				CreatorName = thread.User.UserName,
				CreatorImageUrl = thread.User.ProfileImageUrl,
				CreatorRating = thread.User.Rating,
				CreatedAt = thread.CreatedAt.ToString(),
				PostCount = thread.Posts.Count(),
				Forum = BuildForumListing(thread)
			});

			var model = new ForumTopicModel
			{
				Threads = threadListings,
				Forum = BuildForumListing(forum)
			};

			return View(model);
		}

		/// <summary>
		/// Overload.
		/// Collects the necessary data, generates then returns a Thread object.
		/// </summary>
		/// <param name="thread">ThreadEntity object.</param>
		/// <returns>Object: collection of forums.</returns>
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
		/// <param name="thread">ThreadEntity object.</param>
		/// <returns>Object: collection of forums.</returns>
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
