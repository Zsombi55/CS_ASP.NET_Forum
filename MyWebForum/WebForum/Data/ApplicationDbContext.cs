using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Entities;

namespace WebForum.Data
{
	/// <summary>
	/// Connects: View models, Logic controllers, Database Entity models.
	/// </summary>
	// MAY NOT NEED <ApplicationUser>
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// DB Entity Models:
		// MAY NEED INSTEAD <IdentityUser>
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		public DbSet<ForumEntity> Forums { get; set; }
		public DbSet<ThreadEntity> Threads { get; set; }
		public DbSet<PostEntity> Posts { get; set; }
	}
}
