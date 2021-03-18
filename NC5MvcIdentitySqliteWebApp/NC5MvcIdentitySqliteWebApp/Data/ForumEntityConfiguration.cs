using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public class ForumEntityConfiguration : IEntityTypeConfiguration<ForumEntity>
	{
		public void Configure(EntityTypeBuilder<ForumEntity> builder)
		{
			builder.ToTable("Forums");
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Name)
					.HasMaxLength(100)
					.IsRequired();
			builder.Property(e => e.Description)
					.HasMaxLength(255)
					.IsRequired();
			// "Boards" connection.
			builder.HasOne(f => f.Board)
					.WithMany(b => b.Forums)
					.HasForeignKey(f => f.BoardId)
					.HasConstraintName("FK_Forums_Boards");
		}
	}
}
