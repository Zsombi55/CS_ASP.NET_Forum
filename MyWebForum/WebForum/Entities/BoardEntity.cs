using System.Collections.Generic;

namespace WebForum.Entities
{
	public class BoardEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }


		public IEnumerable<ForumEntity> Forums { get; set; }
	}
}
