using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Forum;
using WebForum.Models.Search;
using WebForum.Models.Thread;

namespace WebForum.Controllers
{
	public class SearchController : Controller
	{
		private readonly IThreadEntity _threadService;

		public SearchController(IThreadEntity threadService)
		{
			_threadService = threadService;
		}

		public IActionResult Results(string searchQuery)
		{
			var threads = _threadService.GetFilteredThreads(searchQuery);

			var zeroResults = (!string.IsNullOrEmpty(searchQuery) && !threads.Any());

			var threadListings = threads.Select(thread => new ThreadListingModel
			{
				Id = thread.Id,
				Title = thread.Title,
				CreatedAt = thread.CreatedAt.ToString(),
				ModifiedAt = thread.ModifiedAt.ToString(),
				AuthorId = thread.User.Id,
				AuthorName = thread.User.UserName,
				AuthorImageUrl = thread.User.ProfileImageUrl,
				AuthorRating = thread.User.Rating,
				PostCount = thread.Posts.Count(),
				Forum = BuildForumListing(thread)
			});

			var model = new SearchResultModel
			{
				Threads = threadListings,
				SearchQuery = searchQuery,
				EmptySerachResults = zeroResults
			};

			return View();
		}

		private ForumListingModel BuildForumListing(ThreadEntity thread)
		{
			var forum = thread.Forum;

			return new ForumListingModel
			{
				Id = forum.Id,
				//ImageUrl = forum.ImageUrl, // Placeholder.
				Title = forum.Title,
				Description = forum.Description
			};
		}

		/// <summary>
		/// Gets the "Search" string to filter child items for listing, from a parent item.
		/// Ex.: threads on a forum, or forums on a board, or select forums on the list of all forums.
		/// </summary>
		/// <param name="searchQuery">String: user input (text to look for), ex. thread name.</param>
		/// <returns>An action: pass "search query" data to & call function to render restults.</returns>
		[HttpPost]
		public IActionResult Search(string searchQuery)
		{
			return RedirectToAction("Results", new { searchQuery });
		}
	}
}
