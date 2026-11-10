namespace MovieCatalog.Core.Entities;

public class Movie
{
    public int Id { get; set; }

    public int? TmdbId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Overview { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public string? PosterPath { get; set; }

    public int? Runtime { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}