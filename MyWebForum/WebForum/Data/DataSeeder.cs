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

		public Task SeedSuperUser()
		{
			var roleStore = new RoleStore<IdentityRole>(_context);
			var userStore = new UserStore<ApplicationUser>(_context);

			var user = new ApplicationUser
			{
				UserName = "user_admin_2@mail.com",
				NormalizedUserName = "USER_ADMIN_2@MAIL.COM",
				Email = "user_admin_2@mail.com",
				EmailConfirmed = true,
				LockoutEnabled = false,
				SecurityStamp = Guid.NewGuid().ToString(),
			};

			var hasher = new PasswordHasher<ApplicationUser>();
			var hashedPass = hasher.HashPassword(user, "Admin-User_2!");
			user.PasswordHash = hashedPass;

			var hasAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");

			if(!hasAdminRole)
			{
				roleStore.CreateAsync(new IdentityRole {
					Name = "Admin",
					NormalizedName = "admin"
				});
			}

			var hasSuperUser = _context.Roles.Any(u => u.NormalizedName == user.UserName);

			if (!hasSuperUser)
			{
				userStore.CreateAsync(user);
				userStore.AddToRoleAsync(user, "Admin");
			}

			_context.SaveChangesAsync();

			return Task.CompletedTask;
		}
	}
}
