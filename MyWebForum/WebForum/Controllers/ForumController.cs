using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Board;
using WebForum.Models.Forum;
using WebForum.Models.Thread;

namespace WebForum.Controllers
{
	public class ForumController : Controller
	{
		private readonly IBoardEntity _boardEntityService;
		private readonly IForumEntity _forumEntityService;
		private readonly IThreadEntity _threadEntityService;

		private readonly IUpload _uploadService;
		private readonly IConfiguration _configuration;

		public ForumController(IThreadEntity threadEntityService, IForumEntity forumEntityService, IBoardEntity boardEntityService, IUpload uploadService, IConfiguration configService)
		{
			_boardEntityService = boardEntityService;
			_forumEntityService = forumEntityService;
			_threadEntityService = threadEntityService;

			_uploadService = uploadService; //For file upload handling, ex. profile pictures.

			_configuration = configService;
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
		/// If the "search query" parameter is NOT empty, filter & collect Threads accordingly.
		/// </summary>
		/// <param name="id">Int: forum ID.</param>
		/// <param name="searchQuery">String: user input (text to look for).</param>
		/// <returns>Object: a Forum's data, its Thread collection, and some of their data.</returns>
		public IActionResult Forum(int id, string searchQuery)
		{
			var forum = _forumEntityService.GetById(id);
			var threads = new List<ThreadEntity>();

			//if (!string.IsNullOrEmpty(searchQuery))
			//{
			//	threads = _threadEntityService.GetFilteredThreads(id, searchQuery).ToList();
			//}
			//threads = forum.Threads.ToList();
			threads = _threadEntityService.GetFilteredThreads(forum, searchQuery).ToList();

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
				AuthorRating = thread.User.Rating,
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
		/// Gets a collection of Threads containing the "Search" string for listing, from the ID-d Forum.
		/// </summary>
		/// <param name="id">Int: forum ID.</param>
		/// <param name="searchQuery">String: user input (text to look for), ex. thread name.</param>
		/// <returns>An action: pass data to & call function to render a Forum's data, its potentially "search query" filtered Thread collection (if the parameter is empty, there is no filtering), and some of their data.</returns>
		[HttpPost]
		public async Task<IActionResult> Search(int id, string searchQuery)
		{
			return RedirectToAction("Forum", new { id, searchQuery });
		}

		// POST : Forum
		/// <summary>
		/// Gets the existing data to which later the User-entered data can be connected to.
		/// [bad explanation, this basically gets references to where the new thread obj. will belong to]
		/// </summary>
		/// <param name="id">Integer: Board obj. ID parameter.</param>
		/// <returns>NewForumModel object: basic new Forum creation data.</returns>
		public IActionResult Create(int id)
		{
			// TODO: somehow link the forum to be created to a Board by user selection.
			//var board = _boardEntityService.GetById(id);

			//var model = new NewForumModel
			//{
			//	BoardId = board.Id,
			//	BoardName = board.Title
			//};

			var model = new NewForumModel{};

			return View(model);
		}

		/// <summary>
		/// Sets/ Posts user-input into a view model then pushes that into the DB.
		/// A form method type post, triggers this; so it doesn't handle it like a typical GET request.
		/// [bad explanation]
		/// </summary>
		/// <param name="model">NewForumModel obj.; returned by the "Create" function above.</param>
		/// <returns>An action: set view to the newly created Forum Index by its ID.</returns>
		[HttpPost]
		public async Task<IActionResult> AddForum(NewForumModel model)
		{
			var imageUri = "images/users/default.png";

			// This will never be used; never adding cloud storage functions; it is just a demo app.
			if (model.ImageUpload != null)
			{
				// Set the Forum's Image to the URI
				var blockBlob = UploadForumImage(model.ImageUpload);
				imageUri = blockBlob.Uri.AbsoluteUri;
			}

			var forum = BuildForum(model);

			//_forumEntityService.Create(forum).Wait();
			await _forumEntityService.Create(forum);

			return RedirectToAction("Index", "Forum", new { id = forum.Id });
		}

		private CloudBlockBlob UploadForumImage(IFormFile file)
		{
			// NOTE: to use Azure web-app storage see:
			// https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core5x

			// Connect to Azure Storage Account Container.
			var connectionString = _configuration.GetConnectionString("AzureStorageAccount");

			// Get Blob Container.
			var container = _uploadService.GetBlobContainer(connectionString, "forum-images");

			// Parse the Content Disposition response header
			var contantDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

			// Grab the filename
			var fileName = contantDisposition.FileName.Trim('"');

			// Get a reference to a Block Blob
			var blockBlob = container.GetBlockBlobReference(fileName);

			// On that, upload our file <-- file uploaded to the cloud/ a server
			blockBlob.UploadFromStreamAsync(file.OpenReadStream()).Wait();

			return blockBlob;
		}

		/// <summary>
		/// Gets user input into a model for making a new Forum.
		/// </summary>
		/// <param name="model">NewForumModel obj.; what is needed at least to make a new one.</param>
		/// <returns>Object: a new ForumEntity based on the NewForumModel data template.</returns>
		private ForumEntity BuildForum(NewForumModel model)
		{
			var board = _boardEntityService.GetById(model.BoardId);

			return new ForumEntity
			{
				Title = model.Title,
				Description = model.Description,
				CreatedAt = DateTime.Now,
				//ImageUrl = imgageUri, // Placeholder; not added; seems silly to have a forum or thread have an picture like a user would have a profile image.
				Board = board
			};
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
