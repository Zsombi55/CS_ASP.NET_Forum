using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NC5MvcIdentitySqliteWebApp.Data.DbEntityConfig
{
	public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
	{
		public void Configure(EntityTypeBuilder<PostEntity> builder)
		{
			builder.ToTable("Posts");
			builder.HasKey(e => e.Id); // "Id"
			builder.HasIndex("ThreadId");
			builder.HasIndex("UserId");

			builder.Property<int>(e => e.Id) // "Id"
					.ValueGeneratedOnAdd()
					.HasColumnType("INTEGER");
			builder.Property<string>(e => e.Content)
					.HasMaxLength(60000)
					.IsRequired();
			builder.Property<DateTime>(e => e.CreatedAt)
					.HasColumnType("TEXT");
			builder.Property<DateTime?>(e => e.ModifiedAt)
					.HasColumnType("TEXT");

			builder.Property<string>(e => e.UserId) // "UserId"
					.HasColumnType("TEXT");
			builder.Property<int?>(e => e.ThreadId) // "ThreadId"
					.HasColumnType("INTEGER");

			// "Users" connection.
			builder.HasOne(p => p.User)
					.WithMany(u => u.Posts)
					.HasForeignKey(u => u.UserId)
					.HasConstraintName("FK_Posts_AspNetUsers");
					//.OnDelete(); ?? - IF Post is deleted leave User, IF User is del. leave Posts

			// "Threads" connection.
			builder.HasOne(p => p.Thread)
					.WithMany(t => t.Posts)
					.HasForeignKey(p => p.ThreadId)
					.HasConstraintName("FK_Posts_Threads");
					//.OnDelete(); ?? - IF Post is deleted leave Thread, IF Thread is del. delete Posts
		}
	}
}
