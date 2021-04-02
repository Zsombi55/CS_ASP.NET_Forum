using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }


		public virtual ApplicationUser User { get; set; }  // IdentityUser ...

		public virtual ThreadEntity Thread { get; set; }


		// MAY NOT NEED :
		//public int ThreadId { get; set; }
		//
		//public virtual ThreadEntity Thread { get; set; }
	}
}
