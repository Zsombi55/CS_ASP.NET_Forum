using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
	{
		public void Configure(EntityTypeBuilder<PostEntity> builder)
		{
			builder.ToTable("Posts");
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Content)
					.HasMaxLength(60000)
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
			builder.Property(e => e.ModifiedAt)
					.HasColumnType("TEXT")
					//.HasColumnType<DateTime>("TEXT")
					//.HasConversion(
					//	v => v.ToString(@"yyyy-MM-dd HH:mm:ss"),
					//	dbv => DateTime.Parse(dbv, CultureInfo.InvariantCulture))
					// -- needed here ?
					// SQLite uses TEXT in UTC format yyyy-MM-dd HH:mm:ss.FFFFFFF
					.IsRequired();
			// "Users" connection -- how to reference a User.Id ?
			builder.Property(e => e.CreatorId)
					.IsRequired();
			// Do I need to make a Users entity then somehow link it with the AspNetCore's User Identity ?
			//
			//builder.HasOne(u => u.User)
			//		.WithMany(b => b.Posts)
			//		.HasForeignKey(f => f.UserId)
			//		.HasConstraintName("FK_Posts_Users");
			// "Threads" connection.
			builder.HasOne(p => p.Thread)
					.WithMany(t => t.Posts)
					.HasForeignKey(p => p.ThreadId)
					.HasConstraintName("FK_Posts_Threads");
		}
	}
}
