using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public class BoardEntityConfiguration : IEntityTypeConfiguration<BoardEntity>
	{
		public void Configure(EntityTypeBuilder<BoardEntity> builder)
		{
			builder.ToTable("Boards");
			builder.HasKey(e => e.Id);
			builder.HasAlternateKey(e => e.Name);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Name).IsRequired();
		}
	}
}
