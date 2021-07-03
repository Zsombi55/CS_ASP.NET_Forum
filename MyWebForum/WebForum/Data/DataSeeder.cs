using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
{
	/// <summary>
	/// Programatically add data to the DB witrhout having to go and write SQL in it.
	/// </summary>
	public class DataSeeder
	{
		private ApplicationDbContext _context;

		public DataSeeder(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task SeedSuperUser()
		{
			var store = new RoleStore<IdentityRole>(_context);
			var userStore = new UserStore<ApplicationUser>(_context);

			var user = new ApplicationUser
			{
				UserName = "ForumAdmin",
				NormalizedUserName = "forumadmin",
				Email = "user_admin_2@mail.com",
				EmailConfirmed = true,
				LockoutEnabled = false,
				SecurityStamp = Guid.NewGuid().ToString(),

			};

			var hasher = new PasswordHasher<ApplicationUser>();
			var hashedPass = hasher.HashPassword(user, "Admin-User-2!");
			user.PasswordHash = hashedPass;

			var hasAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");

			if(!hasAdminRole)
			{
				await store.CreateAsync(new IdentityRole {
					Name = "Admin",
					NormalizedName = "admin"
				});
			}

			var hasSuperUser = _context.Roles.Any(u => u.NormalizedName == user.UserName);

			if (!hasSuperUser)
			{
				await userStore.CreateAsync(user);
				await userStore.AddToRoleAsync(user, "Admin");
			}

			await _context.SaveChangesAsync();
		}
	}
}
