﻿using System;
using System.Collections.Generic;

namespace WebForum.Entities
{
	public class ForumEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }


		public virtual BoardEntity Board { get; set; }


		public IEnumerable<ThreadEntity> Threads { get; set; }
	}
}
