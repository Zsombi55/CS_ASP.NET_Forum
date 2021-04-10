using Microsoft.AspNetCore.Identity;
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

		//public int CreatorId { get; set; }

		//public int Status { get; set; } // TODO: open ~ locked AND normal ~ sticky /priority.

		public IdentityUser User { get; set; } // TODO: ? use an extension with additional data ?

		//public int ForumId { get; set; }

		public ForumEntity Forum { get; set; }

		public IEnumerable<PostEntity> Posts { get; set; }
	}
}
