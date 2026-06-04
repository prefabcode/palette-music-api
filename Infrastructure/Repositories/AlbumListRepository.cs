using Application.Interfaces;
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
    
}