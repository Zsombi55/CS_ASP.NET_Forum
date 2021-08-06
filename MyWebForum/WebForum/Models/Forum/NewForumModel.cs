using Microsoft.AspNetCore.Http;

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

		// Placeholder: not using but the tutorial did with Azure storage, but I'm not making an account just for this application, and the free version would only last for about 1 month anyway, so whoever would look at this and try to run it to see what it is.. wouldn't be able to use the uploading functions anyways.
		public string ImgageUrl { get; set; }
		public IFormFile ImageUpload { get; set; }
	}
}
