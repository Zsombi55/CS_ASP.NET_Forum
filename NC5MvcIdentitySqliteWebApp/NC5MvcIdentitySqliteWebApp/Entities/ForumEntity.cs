using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class ForumEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int BoardId { get; set; }
		// Necessary: scaffolder is too dumb to understand "e=>e.Board.Id" in the configuration.

		public BoardEntity Board { get; set; }

		public IEnumerable<ThreadEntity> Threads { get; set; }
	}
}
