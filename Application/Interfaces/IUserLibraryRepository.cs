namespace Application.Interfaces;

public interface IUserLibraryRepository
{
    Task AddFavoriteAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken);
    
    Task RemoveFavoriteAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken);
    
    Task AddListenedAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken);
    
    Task RemoveListenedAlbumAsync(Guid userId, int albumId, CancellationToken cancellationToken);
}