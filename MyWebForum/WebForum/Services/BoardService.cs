using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;

namespace WebForum.Services
{
	/// <summary> MAYBE :
	/// Take data from the "Data Layer" and Serve it to the WebForum's various controllers.
	/// 
	/// Eg.: if a controller has an Idex() action to display all forums,
	/// this server will ask the ApplicationDbContext with the Entity models to GET it;
	/// then the server gets it from the DataBase, hands it bundled back to the ApplicationDbContext,
	/// which then forwards it to the appropriate Controller for further manipulation & display.
	/// 
	/// Also allows the injection of single instances of the Service to Controllers for all interactions. 
	/// </summary>
	public class BoardService : IBoardEntity
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// BoardService uses EF to interact with the actual Data.
		/// </summary>
		public BoardService(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task Create(BoardEntity board)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int boardId)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets all Boards & their Board.
		/// </summary>
		/// <returns>Every instance of the BoardEntity object.</returns>
		/// <remarks>If not all threads are to be loaded, modify or overload this.</remarks>
		public IEnumerable<BoardEntity> GetAll()
		{
			return _context.Boards.Include(board => board.Forums);
		}

		/// <summary>
		/// Gets a Board object by its ID, and its Forums.
		/// </summary>
		/// <param name="id">Int: forum ID, primary key in DB.</param>
		/// <returns>BoardEntity object: a board.</returns>
		public BoardEntity GetById(int id)
		{
			var board = _context.Boards.Where(board => board.Id == id)
				.Include(board => board.Forums)
					.ThenInclude(forum => forum.Threads)
						.ThenInclude(thread => thread.User)
				.FirstOrDefault();

			return board;
		}

		public Task UpdateBoardTitle(int boardId, string newTitle)
		{
			throw new NotImplementedException();
		}
	}
}
