using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;

namespace NC5MvcIdentitySqliteWebApp.Data.DbEntityConfig
{
	public class ThreadEntityConfiguration : IEntityTypeConfiguration<ThreadEntity>
	{
		public void Configure(EntityTypeBuilder<ThreadEntity> builder)
		{
			builder.ToTable("Threads");
			builder.HasKey(e => e.Id); // "Id"
			builder.HasIndex("ForumId");
			builder.HasIndex("UserId");

			builder.Property<int>(e => e.Id) // "Id"
					.ValueGeneratedOnAdd()
					.HasColumnType("INTEGER");
			builder.Property<string>(e => e.Title)
					.HasColumnType("TEXT")
					.IsRequired();
			builder.Property<DateTime>(e => e.CreatedAt)
					.HasColumnType("TEXT");
			builder.Property<DateTime?>(e => e.ModifiedAt)
					.HasColumnType("TEXT");
			//builder.Property<int>("Status")
			//		.HasColumnType("INTEGER"); // TODO: see ThreadEntity.cs

			builder.Property<string>(e => e.User.Id) // "UserId"
					.HasColumnType("TEXT");
			builder.Property<int?>(e => e.Forum.Id) // "ForumId"
					.HasColumnType("INTEGER");

			// "Users" connection.
			builder.HasOne(t => t.User)
					.WithMany(u => u.Threads)
					.HasForeignKey(u => u.User.Id)
					.HasConstraintName("FK_Threads_AspNetUsers");
					//.OnDelete(); ?? - IF Thread is deleted leave User, IF User is del. leave Threads

			// "Forums" connection.
			builder.HasOne(t => t.Forum)
					.WithMany(f => f.Threads)
					.HasForeignKey(f => f.Forum.Id)
					.HasConstraintName("FK_Threads_Forums");
					//.OnDelete(); ?? - IF Thread is deleted leave Forum, IF Forum is del. delete Threads
		}
	}
}
