using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Post;

namespace WebForum.Models.Thread
{
	/// <summary>
	/// Grabs a collection of "ReplyPostModel", then it is passed to the View.
	/// A Thread's content (1st "post") & a collection of Posts ("ReplyPostModel").
	/// </summary>
	public class ThreadIndexModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public string CreatorId { get; set; }

		public string CreatorName { get; set; }

		public string CreatorImageUrl { get; set; }

		public int CreatorRating { get; set; }

		
		public virtual IEnumerable<ReplyPostModel> Posts { get; set; }
	}
}

// TODO: perhaps try making an abstract "Post" then make all messaging (the thread content here, reply-/posts, private messages, etc.) an instance?