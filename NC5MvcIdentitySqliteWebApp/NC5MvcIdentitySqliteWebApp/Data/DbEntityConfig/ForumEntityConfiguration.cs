using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NC5MvcIdentitySqliteWebApp.Entities;

namespace NC5MvcIdentitySqliteWebApp.Data.DbEntityConfig
{
	public class ForumEntityConfiguration : IEntityTypeConfiguration<ForumEntity>
	{
		public void Configure(EntityTypeBuilder<ForumEntity> builder)
		{
			builder.ToTable("Forums");
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Title)
					.IsRequired();
			builder.Property(e => e.Description)
					.IsRequired();
			// "Boards" connection.
			builder.HasOne(f => f.Board)
					.WithMany(b => b.Forums)
					.HasForeignKey(f => f.BoardId)
					.HasConstraintName("FK_Forums_Boards");
		}
	}
}
