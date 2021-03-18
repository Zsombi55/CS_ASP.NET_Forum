using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public class ThreadEntityConfiguration : IEntityTypeConfiguration<ThreadEntity>
	{
		public void Configure(EntityTypeBuilder<ThreadEntity> builder)
		{
			builder.ToTable("Threads");
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Name)
					.HasMaxLength(255)
					.IsRequired();
			builder.Property(e => e.CreatedAt)
					.HasColumnType("TEXT")
					//.HasColumnType<DateTime>("TEXT")
					//.HasConversion(
					//	v => v.ToString(@"yyyy-MM-dd HH:mm:ss"),
					//	dbv => DateTime.Parse(dbv, CultureInfo.InvariantCulture))
					// -- needed here ?
					// SQLite uses TEXT in UTC format yyyy-MM-dd HH:mm:ss.FFFFFFF
					.IsRequired();
			builder.Property(e => e.CreatorId)
					.IsRequired();
			// "Forums" connection.
			builder.HasOne(t => t.Forum)
					.WithMany(f => f.Threads)
					.HasForeignKey(f => f.ForumId)
					.HasConstraintName("FK_Threads_Forums");
			// "Users" connection -- how to reference a User.Id ?
			// Do I need to make a Users entity then somehow link it with the AspNetCore's User Identity ?
			//
			//builder.HasOne(u => u.User)
			//		.WithMany(b => b.Threads)
			//		.HasForeignKey(f => f.UserId)
			//		.HasConstraintName("FK_Threads_Users");
		}
	}
}
