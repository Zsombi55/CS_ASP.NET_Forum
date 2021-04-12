using System.Collections.Generic;
using NC5MvcIdentitySqliteWebApp.Models.Thread;

namespace NC5MvcIdentitySqliteWebApp.Models.Forum
{
	/// <summary>
	/// View Model: a Forum and its Thread collection.
	/// </summary>
	public class ForumPostsModel
	{
		public ForumViewModel Forum { get; set; }

		public IEnumerable<ThreadViewModel> Threads { get; set; }
	}
}
