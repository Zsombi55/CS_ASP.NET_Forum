using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using NC5MvcIdentitySqliteWebApp.Models;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	/// <summary>
	/// Connects: View models, Logic controllers, Database Entity models.
	/// </summary>
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// DB Entity Models
		public DbSet<BoardEntity> Boards { get; set; }
		public DbSet<ForumEntity> Forums { get; set; }
		public DbSet<ThreadEntity> Threads { get; set; }
		public DbSet<PostEntity> Posts { get; set; }

		// Configuration settings for DB Entity relations.
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new BoardEntityConfiguration());
			builder.ApplyConfiguration(new ForumEntityConfiguration());
			builder.ApplyConfiguration(new ThreadEntityConfiguration());
			builder.ApplyConfiguration(new PostEntityConfiguration());
		}

		// View Models
		public DbSet<NC5MvcIdentitySqliteWebApp.Models.Board> Board { get; set; }

		public DbSet<NC5MvcIdentitySqliteWebApp.Models.Forum> Forum { get; set; }

		public DbSet<NC5MvcIdentitySqliteWebApp.Models.Thread> Thread { get; set; }

		public DbSet<NC5MvcIdentitySqliteWebApp.Models.Post> Post { get; set; }
	}
}
