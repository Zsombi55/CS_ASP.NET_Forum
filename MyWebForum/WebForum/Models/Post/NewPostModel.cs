using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.Post
{
	public class NewPostModel
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

		public string ThreadContent { get; set; }


		public int ForumId { get; set; }

		public string ForumTitle { get; set; }
	}
}

// TODO: perhaps try making an abstract "Post" then make all messaging (the thread content here, reply-/posts, private messages, etc.) an instance?