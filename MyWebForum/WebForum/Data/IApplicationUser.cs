using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
{
	public interface IApplicationUser
	{
		ApplicationUser GetById(string id);
		IEnumerable<ApplicationUser> GetAll();

		Task SetProfileImg(string id, Uri uri);
		Task UpdateRating(string id, Type type);
	}
}
