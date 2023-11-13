﻿using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTracker.Persistence.EntityConfigurations;

public class UserBookEntityTypeConfiguration : IEntityTypeConfiguration<UserBook>
{
    public void Configure(EntityTypeBuilder<UserBook> builder)
    {
        builder.HasKey(x => new {x.BookId, x.UserId});
        builder.Property(x => x.PageCount).IsRequired();
        builder.Property(x => x.DesiredFinishDate).HasColumnType("date").IsRequired();
        builder.Property(x => x.CreatedDateTime).IsRequired();
        builder.Property(x => x.UpdatedDateTime).IsRequired(false);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.UserBooks)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasOne(x => x.User)
           .WithMany(x => x.UserBooks)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
