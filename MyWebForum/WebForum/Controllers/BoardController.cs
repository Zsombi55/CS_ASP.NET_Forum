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
				Board = BuildBoardListing(forum)
			});

			var model = new BoardForumsModel
			{
				Forums = forumListings,
				Board = BuildBoardListing(board)
			};

			return View(model);
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
		/// <param name="forum">ForumEntity object.</param>
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
