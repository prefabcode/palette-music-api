using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PaletteDbContext : DbContext 
{
    public PaletteDbContext(DbContextOptions<PaletteDbContext> options) : base(options) { }

    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumList> AlbumLists { get; set; }
    public DbSet<AlbumListMapping> AlbumListMappings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserListenedAlbum> UserListenedAlbums { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.GoogleSubjectId)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        
        modelBuilder.Entity<UserListenedAlbum>()
            .HasIndex(u => new { u.UserId, u.AlbumId })
            .IsUnique();
    }
}