using NC5MvcIdentitySqliteWebApp.Models.Forum;

namespace NC5MvcIdentitySqliteWebApp.Models.Thread
{
	/// <summary>
	/// View Model: what to show for each record in a list of Threads.
	/// The list is modeled in "ThreadIndexModel".
	/// </summary>
	public class ThreadViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string CreatedAt { get; set; } // Not DateTime for easier manipulation.

		public string ModifiedAt { get; set; }

		//public int Status { get; set; }

		public string AuthorId { get; set; } // Microsoft.AspNetCore.Identity.IdentityUser<string>.Id

		public string AuthorName { get; set; }

		public string AuthorImageUrl { get; set; }

		public int AuthorRating { get; set; }


		public ForumViewModel Forum { get; set; }


		public int PostCount { get; set; }
	}
}
