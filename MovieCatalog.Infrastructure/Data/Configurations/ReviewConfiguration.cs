using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCatalog.Core.Entities;

namespace MovieCatalog.Infrastructure.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews", table =>
        {
            table.HasCheckConstraint(
                "CK_Reviews_Rating_Range",
                "\"Rating\" >= 1 AND \"Rating\" <= 10"
            );
        });

        builder.HasKey(r => r.Id);

        builder.Property(r => r.ReviewerName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.Comment)
            .HasColumnType("text");

        builder.Property(r => r.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .HasColumnType("timestamp with time zone");

        builder.HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}