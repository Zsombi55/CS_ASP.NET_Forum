using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Models.Thread
{
	/// <summary>
	/// Grabs a collection of "ThreadViewModel" objects, which then is passed to the View.
	/// </summary>
	public class ThreadIndexModel
	{
		public IEnumerable<ThreadViewModel> ThreadList { get; set; }
	}
}
