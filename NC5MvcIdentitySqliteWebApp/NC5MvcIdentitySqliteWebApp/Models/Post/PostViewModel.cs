using NC5MvcIdentitySqliteWebApp.Models.Thread;
using System;
using System.ComponentModel.DataAnnotations;

namespace NC5MvcIdentitySqliteWebApp.Models.Post
{
	public class PostViewModel
	{
		public int Id { get; set; }

		[MaxLength(60000)]
		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public string AuthorId { get; set; }

		public string AuthorName { get; set; }

		public int AuthorRating { get; set; }

		public string AuthorImageUrl { get; set; }


		public ThreadViewModel Thread { get; set; }
	}
}
