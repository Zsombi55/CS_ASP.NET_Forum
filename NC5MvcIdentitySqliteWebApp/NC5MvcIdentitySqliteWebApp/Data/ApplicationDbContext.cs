using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<BoardEntity> Boards { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new BoardEntityConfiguration());
		}
	}
}
