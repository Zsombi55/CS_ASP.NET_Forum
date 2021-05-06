namespace WebForum.Models.Forum
{
	/// <summary>
	/// View Model: what to show & what to ask for when creating a new Forum.
	/// used by the "Create new Forum" web-form.
	/// </summary>
	public class NewForumModel
	{
		public int BoardId { get; set; }
		public string BoardName { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }
	}
}
