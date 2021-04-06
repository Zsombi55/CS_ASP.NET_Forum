using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Entities
{
	public class ThreadEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int Status { get; set; }
		//public IEnumerable<StatusModel> Status { get; set; }


		public virtual ApplicationUser User { get; set; } // IdentityUser ...

		public virtual ForumEntity Forum { get; set; }


		public virtual IEnumerable<PostEntity> Posts { get; set; }


		// MAY NOT NEED :
		//public int ForumId { get; set; }
		//
		//public virtual ForumEntity Forum { get; set; }
	}
}
