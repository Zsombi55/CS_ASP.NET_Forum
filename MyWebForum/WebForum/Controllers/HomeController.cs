﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models;
using WebForum.Models.Forum;
using WebForum.Models.Home;
using WebForum.Models.Thread;

namespace WebForum.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IThreadEntity _threadEntityService;

		public HomeController(ILogger<HomeController> logger, IThreadEntity threadEntityService)
		{
			_logger = logger;
			_threadEntityService = threadEntityService;
		}

		/// <summary>
		/// Gets a list/ collection of the latest  " 10 "  Threads and associated data,
		/// then passes the data object to the View() function for display.
		/// </summary>
		/// <returns>Object: a view model with the collected data.</returns>
		public IActionResult Index()
		{
			var model = BuildHomeIndexModel();

			return View(model);
		}

		private HomeIndexModel BuildHomeIndexModel()
		{
			var latestThreads = _threadEntityService.GetLatestThreads(amount: 10);
			
			var threads = latestThreads.Select(thread => new ThreadListingModel
			{
				Id = thread.Id,
				Title = thread.Title,
				AuthorName = thread.User.UserName,
				AuthorId = thread.User.Id,
				AuthorRating = thread.User.Rating, // Author Rating
				CreatedAt = thread.CreatedAt.ToString(),
				PostCount = thread.Posts.Count(),
				Forum = GetForumListingForThread(thread)
			});

			return new HomeIndexModel
			{
				LatestThreads = threads,
				SearchQuery = "" // TODO: HomeController > BuildHomeIndexModel > search query.
			};
		}

		private ForumListingModel GetForumListingForThread(ThreadEntity thread)
		{
			var forum = thread.Forum;

			return new ForumListingModel
			{
				Id = forum.Id,
				Title = forum.Title,
			};
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Application description page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
