using Microsoft.EntityFrameworkCore;
using MovieCatalog.Core.Entities;

namespace MovieCatalog.Infrastructure.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(
        DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();

    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MovieDbContext).Assembly
        );
    }
}