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

		public string CreatedAt { get; set; } // Not DateTime for easier manipulation.

		public string ModifiedAt { get; set; }

		public int Status { get; set; }

		public string AuthorId { get; set; } // Microsoft.AspNetCore.Identity.IdentityUser<string>.Id

		public string AuthorName { get; set; }

		public string AuthorImageUrl { get; set; }

		public int AuthorRating { get; set; }
				

		public ForumListingModel Forum { get; set; }


		public int PostCount { get; set; }
	}
}
