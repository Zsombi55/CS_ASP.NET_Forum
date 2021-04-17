using System.Collections.Generic;

namespace WebForum.Models.Board
{
	/// <summary>
	/// Grabs a collection of "BoardListingModel", then it is passed to the View.
	/// A collection of Forums to show. Each record's details to show are in the "BoardListingModel".
	/// </summary>
	public class BoardIndexModel
	{
		public IEnumerable<BoardListingModel> BoardList { get; set; }
	}
}
