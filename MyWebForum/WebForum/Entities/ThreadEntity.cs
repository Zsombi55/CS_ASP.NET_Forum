using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Entities
{
	public class ThreadEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		[MaxLength(60000)]
		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int Status { get; set; }
		// 0 /00 = Open+Normal; 01 /1 = Open+Sticky (priority); 10 = Closed+Normal; 11 = Closed+Sticky.
		// Open = any Usercan crud; Closed = only staff (admin, mods) can crud, rest read only.
		
		public virtual ApplicationUser User { get; set; } // IdentityUser ...

		public virtual ForumEntity Forum { get; set; }


		public virtual IEnumerable<PostEntity> Posts { get; set; }
	}
}

// TODO: add Status DB table & link in here & PostEntity?