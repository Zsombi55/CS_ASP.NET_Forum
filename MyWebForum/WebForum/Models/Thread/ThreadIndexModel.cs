using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Post;

namespace WebForum.Models.Thread
{
	/// <summary>
	/// Grabs a collection of "PostModel", then it is passed to the View.
	/// A Thread's content (1st "post") and a collection of Posts ("PostModel").
	/// </summary>
	public class ThreadIndexModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public string AuthorId { get; set; }

		public string AuthorName { get; set; }

		public string AuthorImageUrl { get; set; }

		public int AuthorRating { get; set; }

		public bool IsAuthorAdmin { get; set; }

		// These 2 are used to get/ route back to the Forum this Thread belongs to.
		public int ForumId { get; set; }

		public string ForumName { get; set; }


		public virtual IEnumerable<NewPostModel> Posts { get; set; }
	}
}

// TODO: perhaps try making an abstract "Post" then make all messaging (the thread content here, reply-/posts, private messages, etc.) an instance?