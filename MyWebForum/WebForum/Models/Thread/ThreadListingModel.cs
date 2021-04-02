﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.Forum;

namespace WebForum.Models.Thread
{
	public class ThreadListingModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string CreatorName { get; set; }

		public int CreatorRating { get; set; }

		public int CreatorId { get; set; }

		public string CreatedAt { get; set; }


		public ForumListingModel Forum { get; set; }


		public int PostCount { get; set; }
	}
}
