using System.Collections.Generic;
using NC5MvcIdentitySqliteWebApp.Models.Forum;

namespace NC5MvcIdentitySqliteWebApp.Models.Board
{
	/// <summary>
	/// View Model: a Board and its Forum collection.
	/// </summary>
	public class BoardForumsModel
	{
		public BoardViewModel Board { get; set; }

		public IEnumerable<ForumViewModel> Forums { get; set; }
	}
}
