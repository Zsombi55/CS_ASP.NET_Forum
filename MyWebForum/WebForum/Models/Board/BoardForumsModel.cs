using System.Collections.Generic;
using WebForum.Models.Forum;

namespace WebForum.Models.Board
{
	/// <summary>
	/// View Model: a Board and its Forum collection.
	/// </summary>
	public class BoardForumsModel
	{
		public BoardListingModel Board { get; set; }

		public IEnumerable<ForumListingModel> Forums { get; set; }
	}
}
