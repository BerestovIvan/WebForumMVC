using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfiguration
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(topic => topic.Id);
            builder.HasIndex(topic => topic.Id).IsUnique();
            builder.HasIndex(topic => topic.Title).IsUnique();
            builder.Property(topic => topic.Title).HasMaxLength(20).IsRequired();

            builder.HasMany(c => c.Articles).
            WithOne(e => e.Topic)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
