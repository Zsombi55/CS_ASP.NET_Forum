using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Forum;

namespace WebForum.Models.Thread
{
	/// <summary>
	/// View Model: what to show for each record in a list of Threads.
	/// </summary>
	public class ThreadListingModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int Status { get; set; }
		//public IEnumerable<WebForum.Models.StatusModel> Status { get; set; }

		//public int CreatorId { get; set; }
		public string CreatorId { get; set; } // Microsoft.AspNetCore.Identity.IdentityUser<string>.Id

		public string CreatorName { get; set; }

		public string CreatorImageUrl { get; set; }

		public int CreatorRating { get; set; }

		public string CreatedAt { get; set; }


		public ForumListingModel Forum { get; set; }


		public int PostCount { get; set; }
	}
}
