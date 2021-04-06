using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.Forum
{
	/// <summary>
	/// View Model: what to show for each record in a list of Forums.
	/// The list is modeled in "ForumIndexModel".
	/// </summary>
	public class ForumListingModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int Status { get; set; }
		//public IEnumerable<WebForum.Models.StatusModel> Status { get; set; }
	}
}
