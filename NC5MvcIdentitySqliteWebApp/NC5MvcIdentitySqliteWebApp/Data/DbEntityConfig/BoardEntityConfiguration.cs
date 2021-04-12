using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;

namespace NC5MvcIdentitySqliteWebApp.Data.DbEntityConfig
{
	public class BoardEntityConfiguration : IEntityTypeConfiguration<BoardEntity>
	{
		public void Configure(EntityTypeBuilder<BoardEntity> builder)
		{
			builder.ToTable("Boards");
			builder.HasKey(e => e.Id);
			builder.HasAlternateKey(e => e.Title);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Title).IsRequired();
		}
	}
}
