using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebForum.Entities;

namespace WebForum.Data
{
	/// <summary>
	/// Connects: View models, Logic controllers, Database Entity models.
	/// </summary>
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// DB Entity Models:
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		//public DbSet<BoardEntity> Boards { get; set; }
		public DbSet<ForumEntity> Forums { get; set; }
		public DbSet<ThreadEntity> Threads { get; set; }
		public DbSet<PostEntity> Posts { get; set; }
	}
}
