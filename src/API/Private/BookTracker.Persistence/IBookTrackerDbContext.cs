using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Persistence;

public interface IBookTrackerDbContext
{
    DbSet<Book> Book { get; set; }
    DbSet<Author> Author { get; set; }
    DbSet<Genre> Genre { get; set; }
    DbSet<Publisher> Publisher { get; set; }
    DbSet<BookAuthor> BookAuthor { get; set; }
    DbSet<Mood> Mood { get; set; }
    DbSet<Role> Role { get; set; }
    DbSet<User> User { get; set; }
    DbSet<UserBook> UserBook { get; set; }
    DbSet<UserBookStatus> UserBookStatuse { get; set; }
    DbSet<UserBookTracker> UserBookTracker { get; set; }
    DbSet<Language> Language { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
