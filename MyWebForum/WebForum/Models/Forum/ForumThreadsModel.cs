using System.Collections.Generic;
using WebForum.Models.Thread;

namespace WebForum.Models.Forum
{
	/// <summary>
	/// View Model: a Forum and its Thread collection.
	/// </summary>
	public class ForumThreadsModel
	{
		public ForumListingModel Forum { get; set; }

		public IEnumerable<ThreadListingModel> Threads { get; set; }
	}
}
