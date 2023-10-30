namespace BookTracker.Persistence.Entities;

public class UserBook
{
    public string BookId { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public int PageCount { get; set; }
    public DateTime DesiredFinishDate { get; set; }
    public DateTime CreatedDinishDate { get; set; }
    public DateTime? UpdatedDinishDate { get; set; }

    public Book? Book { get; set; }
    public User? User { get; set; }

    public IEnumerable<UserBookTracker>? UserBookTrackers { get; set; }

}
