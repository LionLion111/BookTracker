using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace BookTracker.Persistence;

public class BookTrackerDbContext : DbContext
{
	
	public BookTrackerDbContext(DbContextOptions<BookTrackerDbContext> options) : base(options)
	{

	}

	public DbSet<Book> Book { get; set; } = null!;
	public DbSet<Author> Author { get; set; } = null!;
	public DbSet<Genre> Genre { get; set; } = null!;
	public DbSet<Publisher> Publisher { get; set; } = null!;
	public DbSet<BookAuthor> BookAuthor { get; set; } = null!;
	public DbSet<Mood> Mood { get; set; } = null!;
    public DbSet<Role> Role { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<UserBook> UserBook { get; set; } = null!;
	public DbSet<UserBookStatus> UserBookStatus { get; set; } = null!;
	public DbSet<UserBookTracker> UserBookTracker { get; set; } = null!;
	public DbSet<Language> languages { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookTrackerDbContext).Assembly);
    }

}
