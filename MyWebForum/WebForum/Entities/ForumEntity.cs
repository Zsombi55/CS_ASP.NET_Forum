using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Forum;

namespace WebForum.Entities
{
	public class ForumEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime? CreatedAt { get; set; }

		public int Status { get; set; }
		//public IEnumerable<ForumStatusModel> Status { get; set; }


		public IEnumerable<ThreadEntity> Threads { get; set; }


		// MAY NOT NEED :
		//public int BoardId { get; set; }
		//
		//public virtual BoardEntity Board { get; set; }
	}
}
