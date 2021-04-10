using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

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
			builder.Property<int>("Id")
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
			builder.Property<string>("UserId")
					.HasColumnType("TEXT"); // IdentityUser.Id
			builder.Property<int?>("ForumId")
					.HasColumnType("INTEGER");

			// "Users" connection.
			builder.HasOne(t => t.User)
					.WithMany(u => u.Threads)
					.HasForeignKey(u => u.User.Id)
					.HasConstraintName("FK_Threads_Users");
			// "Forums" connection.
			builder.HasOne(t => t.Forum)
					.WithMany(f => f.Threads)
					.HasForeignKey(f => f.Forum.Id)
					.HasConstraintName("FK_Threads_Forums");
		}
	}
}
