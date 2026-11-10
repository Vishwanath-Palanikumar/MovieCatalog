namespace MovieCatalog.Core.Entities;

public class Genre
{
    public int Id { get; set; }

    public int TmdbGenreId { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigation property
    public ICollection<MovieGenre> MovieGenres { get; set; }
        = new List<MovieGenre>();
}
