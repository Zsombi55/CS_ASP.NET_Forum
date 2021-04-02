using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models.Forum
{
	/// <summary>
	/// Grabs a collection of "ForumListingModel", then it is passed to the View.
	/// </summary>
	public class ForumIndexModel
	{
		public IEnumerable<ForumListingModel> ForumList { get; set; }
	}
}
