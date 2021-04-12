using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Models.Board
{
	/// <summary>
	/// Grabs a collection of "BoardViewModel" objects, which then is passed to the View.
	/// </summary>
	public class BoardIndexModel
	{
		public IEnumerable<BoardViewModel> BoardList { get; set; }
	}
}
