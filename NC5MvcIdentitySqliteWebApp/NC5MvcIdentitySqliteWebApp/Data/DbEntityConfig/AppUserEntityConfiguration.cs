using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;

namespace NC5MvcIdentitySqliteWebApp.Data.DbEntityConfig
{
    public class AppUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
            builder.ToTable("AspNetUsers");
			builder.HasKey(e => e.Id); // "Id"
			builder.HasIndex("NormalizedUserName")
                    .HasDatabaseName("UserNameIndex")
                    .IsUnique();
            builder.HasIndex("NormalizedEmail")
                    .HasDatabaseName("EmailIndex");

            builder.Property<string>("Id")
                    .HasColumnType("TEXT");
            builder.Property<string>("UserName")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");
            builder.Property<string>("NormalizedUserName")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");
            builder.Property<string>("PasswordHash")
                    .HasColumnType("TEXT");
            builder.Property<string>("Email")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");
            builder.Property<string>("NormalizedEmail")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");
            builder.Property<string>("PhoneNumber")
                    .HasColumnType("TEXT");
            builder.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("INTEGER");
            builder.Property<bool>("EmailConfirmed")
                    .HasColumnType("INTEGER");

            builder.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("INTEGER");
            builder.Property<bool>("LockoutEnabled")
                    .HasColumnType("INTEGER");
            builder.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("TEXT");
            builder.Property<int>("AccessFailedCount")
                    .HasColumnType("INTEGER");
            builder.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("TEXT");
            builder.Property<string>("SecurityStamp")
                    .HasColumnType("TEXT");

            builder.Property<int>("Rating")
                    .HasColumnType("INTEGER");
            builder.Property<DateTime>("MemberSince")
                    .HasColumnType("TEXT");
            builder.Property<string>("ProfileImageUrl")
                    .HasColumnType("TEXT");
            builder.Property<bool>("IsActive")
                    .HasColumnType("INTEGER");
        }
	}
}
