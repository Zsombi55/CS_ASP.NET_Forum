using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class BoardEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public List<ForumEntity> Forums { get; set; }
	}
}
