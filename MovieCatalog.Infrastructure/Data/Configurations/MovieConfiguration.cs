using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCatalog.Core.Entities;

namespace MovieCatalog.Infrastructure.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies", table =>
        {
            table.HasCheckConstraint(
                "CK_Movies_Runtime_Positive",
                "\"Runtime\" IS NULL OR \"Runtime\" > 0"
            );
        });

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(m => m.Overview)
            .HasColumnType("text");

        builder.Property(m => m.ReleaseDate)
            .HasColumnType("date");

        builder.Property(m => m.PosterPath)
            .HasMaxLength(500);

        builder.Property(m => m.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(m => m.UpdatedAt)
            .HasColumnType("timestamp with time zone");

        builder.HasIndex(m => m.TmdbId)
            .IsUnique();
    }
}