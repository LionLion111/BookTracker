using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace BookTracker.Persistence.EntityConfigurations;

public class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(x => new {x.AuthorId, x.BookId });

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.AuthorId);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.BookId);
    }
}
