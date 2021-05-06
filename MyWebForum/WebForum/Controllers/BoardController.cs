using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.Board;
using WebForum.Models.Forum;

namespace WebForum.Controllers
{
	public class BoardController : Controller
	{
		private readonly IBoardEntity _boardEntityService;
		private readonly IForumEntity _forumEntityService;

		public BoardController(IBoardEntity boardEntityService)
		{
			_boardEntityService = boardEntityService;
		}

		// GET : Board
		/// <summary>
		/// Gets a "Microsoft.AspNetCore.Mvc.ViewResult" object that renders a View to the response.
		/// The MVC framework will look for a View called "Index" in a folder called "Board".
		/// </summary>
		public IActionResult Index()
		{
			var boards = _boardEntityService.GetAll()
				.Select(board => new BoardListingModel {
					Id = board.Id,
					Title = board.Title
				});

			var model = new BoardIndexModel
			{
				BoardList = boards
			};

			return View(model);
		}

		// GET : Board
		/// <summary>
		/// Gets a Board by its ID with all of its Forums for listing.
		/// </summary>
		/// <param name="id">Int: board ID.</param>
		/// <returns>Object: a Board's data, its Forum collection, and some of their data.</returns>
		public IActionResult Board(int id)
		{
			var board = _boardEntityService.GetById(id);
			var forums = board.Forums;

			var forumListings = forums.Select(forum => new ForumListingModel
			{
				Id = forum.Id, // int
				Title = forum.Title,
				Description = forum.Description,
				Board = BuildBoardListing(forum)
			});

			var model = new BoardForumsModel
			{
				Forums = forumListings,
				Board = BuildBoardListing(board)
			};

			return View(model);
		}

		// POST : Board
		/// <summary>
		/// Gets the existing data to which later the User-entered data can be connected to.
		/// [bad explanation, this basically gets references to where the new thread obj. will belong to]
		/// </summary>
		/// <param name="id">Integer: ?? obj. ID parameter.</param>
		/// <returns>NewForumModel object: basic new Board creation data.</returns>
		public IActionResult Create()
		{
			var model = new NewBoardModel{};
			//TODO: no regular Users should be able to use this, only Mods & Admins !

			return View(model);
		}

		/// <summary>
		/// Sets/ Posts user-input into a view model then pushes that into the DB.
		/// A form method type post, triggers this; so it doesn't handle it like a typical GET request.
		/// [bad explanation]
		/// </summary>
		/// <param name="model">NewBoardModel obj.; returned by the "Create" function above.</param>
		/// <returns>An action: set view to the newly created Board Index by its ID.</returns>
		[HttpPost]
		public async Task<IActionResult> AddBoard(NewBoardModel model)
		{
			var board = BuildBoard(model);

			_boardEntityService.Create(board).Wait();

			return RedirectToAction("Index", "Board", new { id = board.Id });
		}

		/// <summary>
		/// Gets user input into a model for making a new Board.
		/// </summary>
		/// <param name="model">NewBoardModel obj.; what is needed at least to make a new one.</param>
		/// <returns>Object: a new BoardEntity based on the NewBoardModel data template.</returns>
		private BoardEntity BuildBoard(NewBoardModel model)
		{
			return new BoardEntity
			{
				Title = model.Title
			};
		}

		/// <summary>
		/// Overload.
		/// Collects the necessary data, generates then returns a Forum object for a Board.
		/// </summary>
		/// <param name="forum">ForumEntity object.</param>
		/// <returns>BoardEntity object: a board based on the given forum.</returns>
		private BoardListingModel BuildBoardListing(ForumEntity forum)
		{
			var board = forum.Board;

			return BuildBoardListing(board);
		}

		/// <summary>
		/// Collects the necessary data, generates then returns a Board object.
		/// </summary>
		/// <param name="board">ForumEntity object.</param>
		/// <returns>BoardListingModel object: a board.</returns>
		private BoardListingModel BuildBoardListing(BoardEntity board)
		{
			return new BoardListingModel
			{
				Id = board.Id,
				Title = board.Title
			};
		}
	}
}
