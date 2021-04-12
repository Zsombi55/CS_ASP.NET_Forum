namespace NC5MvcIdentitySqliteWebApp.Models.Board
{
	/// <summary>
	/// View Model: what to show for each record in a list of Boards.
	/// The list is modeled in "BoardIndexModel".
	/// </summary>
	public class BoardViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }
	}
}
