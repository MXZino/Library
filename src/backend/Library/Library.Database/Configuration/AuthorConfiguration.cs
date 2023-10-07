using Library.Database.Abstract.Base;
using Library.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Database.Configuration;

public class AuthorConfiguration : BaseEntityConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder
            .HasMany<Book>(x => x.Books)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId);
    }
}