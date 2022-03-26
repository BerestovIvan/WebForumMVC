using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(applicationUser => applicationUser.Email).IsUnique();
            builder.Property(applicationUser => applicationUser.Email).IsRequired();
            builder.HasKey(applicationUser => applicationUser.Id);

            builder.HasMany(c => c.CreatedComments).
            WithOne(e => e.ApplicationUser)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(c => c.CreatedArticles).
             WithOne(e => e.Creator)
             .OnDelete(DeleteBehavior.ClientCascade);


        }
    }
}
