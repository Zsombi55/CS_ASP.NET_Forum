using System.Collections.Generic;
using WebForum.Models.Thread;

namespace WebForum.Models.Search
{
	public class SearchResultModel
	{
		public IEnumerable<ThreadListingModel> Threads { get; set; }
		public string SearchQuery { get; set; }
		public bool EmptySerachResults { get; set; }
	}
}
