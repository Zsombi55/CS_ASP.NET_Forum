using System;
using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Models
{
	public class Thread
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime? CreatedAt { get; set; }

		public int Creator { get; set; }

		public ThreadStatus Status { get; set; }

		public List<Post> Posts { get; set; }
	}
}