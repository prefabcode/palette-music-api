using Application.Interfaces;
using Application.ResponseModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AlbumListRepository : IAlbumListRepository
{
    private readonly PaletteDbContext _db;
    
    public AlbumListRepository(PaletteDbContext db) => _db = db;
    
    public async Task<List<AlbumList>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.AlbumLists
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<SluggedAlbumListResponse?> GetBySlugAsync(Guid userId, string slug, CancellationToken cancellationToken)
    {
        var sluggedAlbumListResponse = await _db.AlbumLists.Where(a => a.Slug == slug).Select(u =>
            new SluggedAlbumListResponse()
            {
                ListName = u.ListName,
                Slug = u.Slug,
                UserAlbums = u.AlbumListMappings.Select(a => new UserAlbumResponse()
                {
                    AlbumId = a.AlbumId,
                    AlbumName = a.Album.AlbumName,
                    ArtistName = a.Album.ArtistName,
                    ImageUrl = a.Album.ImageUrl,
                    SpotifyUrl = a.Album.SpotifyUrl,
                    QobuzUrl = a.Album.QobuzUrl,
                    YoutubeUrl = a.Album.YoutubeUrl,
                    AppleMusicUrl = a.Album.AppleMusicUrl,
                    SoundCloudUrl = a.Album.SoundCloudUrl,
                    TidalUrl = a.Album.TidalUrl,
                    DeezerUrl = a.Album.DeezerUrl,
                    HasListened = _db.UserListenedAlbums.Any(l => l.UserId == userId && l.AlbumId == a.AlbumId),
                    HasFavorited = _db.UserFavoritedAlbums.Any(f => f.UserId == userId && f.AlbumId == a.AlbumId),
                }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);

        return sluggedAlbumListResponse;
       
    }
    
}