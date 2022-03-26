using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(article => article.Id);
            builder.HasIndex(article => article.Id).IsUnique();
            builder.Property(article => article.Text).HasMaxLength(1500).IsRequired();
            builder.Property(article => article.Title).HasMaxLength(60).IsRequired();
            builder.Property(article => article.CreatorId).IsRequired();
            builder.Property(article => article.TopicId).IsRequired();

            builder.HasMany(c => c.Comments).
            WithOne(e => e.Article)
            .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
