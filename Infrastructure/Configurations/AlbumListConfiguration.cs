using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AlbumListConfiguration : IEntityTypeConfiguration<AlbumList>
{
    public void Configure(EntityTypeBuilder<AlbumList> builder)
    {
        builder.Property(a => a.ListType)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}