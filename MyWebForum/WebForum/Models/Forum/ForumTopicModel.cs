using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Thread;

namespace WebForum.Models.Forum
{
	/// <summary>
	/// View Model: collection of Forums by topic and their Threads.
	/// </summary>
	public class ForumTopicModel
	{
		public ForumListingModel Forum { get; set; }

		public IEnumerable<ThreadListingModel> Threads { get; set; }
	}
}
