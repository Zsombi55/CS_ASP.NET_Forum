using System;
using System.Collections.Generic;

namespace WebForum.Entities
{
	public class ForumEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }


		public IEnumerable<ThreadEntity> Threads { get; set; }
	}
}

// FOR ADDING "BOARDS", THE CATEGORY LEVEL, AFTER THESE 3 ARE DONE & MOSTLY WORKING.
//public virtual BoardEntity Board { get; set; }
// BoardEntity ::: public IEnumerable<ForumEntity> Forums { get; set; }