namespace MovieCatalog.Core.Entities;

public class Review
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public string ReviewerName { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // Navigation property
    public Movie Movie { get; set; } = null!;
}