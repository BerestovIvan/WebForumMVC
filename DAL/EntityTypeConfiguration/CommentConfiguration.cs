using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.Id);
            builder.HasIndex(comment => comment.Id).IsUnique();
            builder.Property(comment => comment.Text).HasMaxLength(300).IsRequired();
            builder.Property(comment => comment.ArticleId).IsRequired();
            builder.Property(comment => comment.ApplicationUserId).IsRequired();
        }
    }
}
