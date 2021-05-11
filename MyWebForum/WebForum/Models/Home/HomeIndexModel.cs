using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Thread;

namespace WebForum.Models.Home
{
	public class HomeIndexModel
	{
		public string SearchQuery { get; set; }
	
		public IEnumerable<ThreadListingModel> LatestThreads { get; set; }

		//
	}
}
