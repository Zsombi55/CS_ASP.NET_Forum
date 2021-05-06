using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.Thread
{
	/// <summary>
	/// View Model: what to show & what to ask for when creating a new Thread.
	/// used by the "Create new Thread" web-form.
	/// </summary>
	public class NewThreadModel
	{
		public int ForumId { get; set; }
		public string ForumName { get; set; }
		public string AuthorName { get; set; }

		public string Title { get; set; }
		[MaxLength(60000)]
		public string Content { get; set; }
	}
}
