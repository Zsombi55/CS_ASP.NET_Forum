using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Models
{
	public class Forum
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public List<Thread> Threads { get; set; }
	}
}