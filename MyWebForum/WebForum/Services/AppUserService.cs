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

		/// <summary>
		/// Sets the current user's Rating attribute to a new value in an an asynchronous manner.
		/// </summary>
		/// <param name="userId">Current user's ID.</param>
		/// <param name="type">DB Entity model, eg.: Thread or Post.</param>
		public async Task UpdateRating(string userId, Type type)
		{
			var user = GetById(userId);
			user.Rating = CalculateRating(type, user.Rating);
			await _context.SaveChangesAsync();
		}

		private int CalculateRating(Type type, int rating)
		{
			var i = 0;

			if(type == typeof(ThreadEntity)) { i = 1;  }
			if (type == typeof(PostEntity)) { i = 3; }

			return rating + i;
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
