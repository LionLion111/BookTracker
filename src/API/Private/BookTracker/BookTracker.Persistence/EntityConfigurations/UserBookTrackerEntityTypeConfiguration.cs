using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BookTracker.Persistence.EntityConfigurations;

public class UserBookTrackerEntityTypeConfiguration : IEntityTypeConfiguration<UserBookTracker>
{
    public void Configure(EntityTypeBuilder<UserBookTracker> builder)
    {
        builder.HasKey(x => new { x.Id, x.BookId, x.UserId });
        builder.Property(x => x.Id).HasValueGenerator<MaxIdValueGenerator>();
        builder.Property(x => x.CreatedDateTime).IsRequired();
        builder.Property(x => x.FinishedDateTime).IsRequired();
        builder.Property(x => x.PageCount).IsRequired();

        builder
           .HasOne(x => x.UserBook)
           .WithMany(x => x.UserBookTrackers)
           .HasForeignKey(x => new { x.BookId, x.UserId })
           .OnDelete(DeleteBehavior.Restrict);
    }

    private sealed class MaxIdValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry)
        {
            var dbContext = (BookTrackerDbContext)entry.Context;

            var bookId = (int)entry.Property("BookId").CurrentValue!;
            var userId = (int)entry.Property("UserId").CurrentValue!;

            var maxId = dbContext.UserBookTracker
                .Where(x => x.BookId == bookId && x.UserId == userId)
                .Max(x => (int?)x.Id) ?? 0;
            return maxId + 1;
        }
    }
}
