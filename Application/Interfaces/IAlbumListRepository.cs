using Domain.Entities;

namespace Application.Interfaces;

public interface IAlbumListRepository
{
    Task<List<AlbumList>> GetAllAsync(CancellationToken cancellationToken);
}