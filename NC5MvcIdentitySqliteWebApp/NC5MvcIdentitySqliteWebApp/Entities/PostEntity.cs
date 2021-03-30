using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public IdentityUser Creator { get; set; }

		public int ThreadId { get; set; }

		public ThreadEntity Thread { get; set; }

		public List<PostEntity> PostReplies { get; set; }
	}
}
