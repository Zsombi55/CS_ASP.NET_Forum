using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Models.Forum
{
	/// <summary>
	/// Grabs a collection of "ForumViewModel" objects, which then is passed to the View.
	/// </summary>
	public class ForumIndexModel
	{
		public IEnumerable<ForumViewModel> ForumList { get; set; }
	}
}
