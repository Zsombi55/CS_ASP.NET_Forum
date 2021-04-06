using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.Post
{
	public class ReplyPostModel
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public string CreatorId { get; set; }

		public string CreatorName { get; set; }

		public int CreatorRating { get; set; }

		public string CreatorImageUrl { get; set; }


		public int PostId { get; set; }
	}
}

// TODO: see "ThreadIndexModel.cs".