using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		[StringLength(60000)]
		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }


		public virtual ApplicationUser User { get; set; }  // IdentityUser ...

		public virtual ThreadEntity Thread { get; set; }
	}
}

// TODO: still not sure if the Thread.Content should be a special abstract Post instance or remain as is.
// TODO: add Status DB table & link in here & ThreadEntity.