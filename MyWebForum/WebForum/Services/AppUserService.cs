using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;

namespace WebForum.Services
{
	public class AppUserService : IApplicationUser
	{
		private readonly ApplicationDbContext _context;

		public AppUserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<ApplicationUser> GetAll()
		{
			return _context.ApplicationUsers;
		}

		public ApplicationUser GetById(string id)
		{
			return GetAll().FirstOrDefault(user => user.Id == id);
		}

		public Task IncrementRating(string id, Type type)
		{
			throw new NotImplementedException();
		}

		public async Task SetProfileImg(string id, Uri uri)
		{
			var user = GetById(id);

			user.ProfileImageUrl = uri.AbsoluteUri;
			_context.Update(user);
			await _context.SaveChangesAsync();
		}
	}
}
