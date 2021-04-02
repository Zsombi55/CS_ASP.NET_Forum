using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.Forum
{
	public class ForumListingModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int Status { get; set; }
		//public IEnumerable<ForumStatusModel> Status { get; set; }
	}
}
