namespace WebForum.Models.Board
{
	/// <summary>
	/// View Model: what to show for each record in a list of Boards.
	/// The list is modeled in "BoardIndexModel".
	/// </summary>
	public class BoardListingModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }
	}
}
