namespace WebForum.Models.Board
{
	/// <summary>
	/// View Model: what to show & what to ask for when creating a new Board.
	/// used by the "Create new Board" web-form.
	/// </summary>
	public class NewBoardModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
