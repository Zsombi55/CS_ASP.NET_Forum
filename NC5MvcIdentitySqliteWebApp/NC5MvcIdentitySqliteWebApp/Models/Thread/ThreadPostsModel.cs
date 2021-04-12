using System.Collections.Generic;
using NC5MvcIdentitySqliteWebApp.Models.Post;

namespace NC5MvcIdentitySqliteWebApp.Models.Thread
{
	/// <summary>
	/// View Model: a Thread and its Post collection.
	/// </summary>
	public class ThreadPostsModel
	{
		public ThreadViewModel Forum { get; set; }

		public IEnumerable<PostViewModel> Posts { get; set; }
	}
}
