using System;

namespace NC5MvcIdentitySqliteWebApp.Models
{
	public class Post
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int Creator { get; set; }

		// this is wrong, I want to show select owner-User data, eg.: name, picture, etc. not an Id.  
	}
}