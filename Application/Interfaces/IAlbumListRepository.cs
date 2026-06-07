using Application.ResponseModels;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAlbumListRepository
{
    Task<List<AlbumList>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<SluggedAlbumListResponse?> GetBySlugAsync(Guid userId, string slug, CancellationToken cancellationToken);
}