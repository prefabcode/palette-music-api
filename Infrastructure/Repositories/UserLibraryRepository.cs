using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserLibraryRepository : IUserLibraryRepository
{
    private readonly PaletteDbContext _db;
    
    public UserLibraryRepository(PaletteDbContext db) => _db = db;

    public async Task AddFavoriteAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken)
    {
        if (await _db.UserFavoritedAlbums.AnyAsync(x => x.UserId == userId && x.AlbumId == albumId, cancellationToken))
        {
            return;
        }
        
        _db.UserFavoritedAlbums.Add(new UserFavoritedAlbum()
        {
            UserId = userId,
            AlbumId = albumId,
            FavoritedAt = DateTime.UtcNow,
        });
        
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveFavoriteAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken)
    {
        var existing = await _db.UserFavoritedAlbums
            .FirstOrDefaultAsync(x => x.UserId == userId && x.AlbumId == albumId, cancellationToken);

        if (existing == null)
        {
            return;
        }
        
        _db.UserFavoritedAlbums.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);
        
    }

    public async Task AddListenedAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken)
    {
        if (await _db.UserListenedAlbums.AnyAsync(x => x.UserId == userId && x.AlbumId == albumId, cancellationToken))
        {
            return;
        }
        
        _db.UserListenedAlbums.Add(new UserListenedAlbum()
        {
            UserId = userId,
            AlbumId = albumId,
            ListenedAt = DateTime.UtcNow,
        });
        
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveListenedAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken)
    {
        var existing = await _db.UserListenedAlbums
            .FirstOrDefaultAsync(x => x.UserId == userId && x.AlbumId == albumId, cancellationToken);
        
        if (existing == null)
        {
            return;
        }
        
        _db.UserListenedAlbums.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);
    }
}