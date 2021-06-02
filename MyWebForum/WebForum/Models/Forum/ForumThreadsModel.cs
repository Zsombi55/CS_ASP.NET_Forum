using System.Collections.Generic;
using WebForum.Models.Thread;

namespace WebForum.Models.Forum
{
	/// <summary>
	/// View Model: a Forum, its Thread collection, and relevant search query string.
	/// </summary>
	public class ForumThreadsModel
	{
		public ForumListingModel Forum { get; set; }

		public IEnumerable<ThreadListingModel> Threads { get; set; }


		public string SearchQuery { get; set; }
	}
}
