using System.Collections.Generic;

namespace WebForum.Models.AppUser
{
	public class ProfileListModel
	{
		public IEnumerable<ProfileModel> UserProfiles { get; set; }
	}
}
