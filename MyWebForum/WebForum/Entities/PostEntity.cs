using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		[MaxLength(60000)]
		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }


		public virtual ApplicationUser User { get; set; }  // IdentityUser ...

		public virtual ThreadEntity Thread { get; set; }
	}
}

// TODO: add Status DB table & link in here & ThreadEntity?