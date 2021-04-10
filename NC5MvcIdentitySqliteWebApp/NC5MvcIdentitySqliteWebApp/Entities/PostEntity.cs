using System;
using System.ComponentModel.DataAnnotations;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		[MaxLength(60000)]
		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public ApplicationUser User { get; set; } // TODO: will add an extension with additional data.

		public ThreadEntity Thread { get; set; }
	}
}
