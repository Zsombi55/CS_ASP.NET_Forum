using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class ThreadEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime? CreatedAt { get; set; }

		public int CreatorId { get; set; }

		public int ForumId { get; set; }

		public ForumEntity Forum { get; set; }

		//public List<PostEntity> Posts { get; set; }
	}
}
