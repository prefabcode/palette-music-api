using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserFavoritedAlbumConfiguration : IEntityTypeConfiguration<UserFavoritedAlbum>
{
    public void Configure(EntityTypeBuilder<UserFavoritedAlbum> builder)
    {
        builder.HasIndex(f => new { f.UserId, f.AlbumId }).IsUnique();
    }
}