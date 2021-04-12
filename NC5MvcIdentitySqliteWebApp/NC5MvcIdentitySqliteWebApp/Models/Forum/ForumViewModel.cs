namespace NC5MvcIdentitySqliteWebApp.Models.Forum
{
	/// <summary>
	/// View Model: what to show for each record in a list of Forums.
	/// The list is modeled in "ForumIndexModel".
	/// </summary>
	public class ForumViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }
	}
}
