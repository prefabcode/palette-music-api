using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserListenedAlbumConfiguration : IEntityTypeConfiguration<UserListenedAlbum>
{
    public void Configure(EntityTypeBuilder<UserListenedAlbum> builder)
    {
        builder.HasIndex(u => new { u.UserId, u.AlbumId }).IsUnique();
    }
}