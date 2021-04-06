using System.Collections.Generic;

namespace WebForum.Models.Forum
{
	/// <summary>
	/// Grabs a collection of "ForumListingModel", then it is passed to the View.
	/// A collection of Forums to show. Each record's details to show are in the "ForumListingModel".
	/// </summary>
	public class ForumIndexModel
	{
		public IEnumerable<ForumListingModel> ForumList { get; set; }
	}
}
