using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.Post
{
	/// <summary>
	/// A generic Post's content.
	/// </summary>
	public class PostIndexModel
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime CreatedAt { get; set; } // Not DateTime for easier manipulation.

		public DateTime? ModifiedAt { get; set; }


		public string AuthorId { get; set; }

		public string AuthorName { get; set; }

		public int AuthorRating { get; set; }

		public string AuthorImageUrl { get; set; }

		public bool IsAuthorAdmin { get; set; }


		public int ThreadId { get; set; }

		public string ThreadTitle { get; set; }
	}
}
