using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class ForumEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int BoardId { get; set; }

		public BoardEntity Board { get; set; }

		public List<ThreadEntity> Threads { get; set; }
	}
}
