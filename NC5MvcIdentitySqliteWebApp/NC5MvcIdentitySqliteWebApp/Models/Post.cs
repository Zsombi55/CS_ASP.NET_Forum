using System;

namespace NC5MvcIdentitySqliteWebApp.Models
{
	public class Post
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int CreatorId { get; set; }
	}
}