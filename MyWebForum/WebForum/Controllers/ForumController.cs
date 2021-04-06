using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Forum;

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

		// GET : Topic
		public IActionResult Topic(int id)
		{
			var forum = _forumEntityService.GetById(id);
			var thread = _threadEntityService.GetFilteredThreads(searchQuery: s);

			//var threadListings = ... 

			return View();
		}
	}
}
