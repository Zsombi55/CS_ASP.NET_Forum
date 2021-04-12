using System;
using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class ThreadEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public string UserId { get; set; }
		// Necessary: scaffolder is too dumb to understand "e=>e.User.Id" in the configuration.

		//public int Status { get; set; } // TODO: open ~ locked AND normal ~ sticky /priority.

		public ApplicationUser User { get; set; } // TODO: will add an extension with additional data.

		public int ForumId { get; set; }
		// Necessary: scaffolder is too dumb to understand "e=>e.Forum.Id" in the configuration.

		public ForumEntity Forum { get; set; }

		public IEnumerable<PostEntity> Posts { get; set; }
	}
}
