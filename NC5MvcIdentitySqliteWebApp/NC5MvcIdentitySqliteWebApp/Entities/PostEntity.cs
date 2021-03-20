﻿using System;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int CreatorId { get; set; }

		public int ThreadId { get; set; }

		public ThreadEntity Thread { get; set; }
	}
}
