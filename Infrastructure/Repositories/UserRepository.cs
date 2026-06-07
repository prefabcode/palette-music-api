using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PaletteDbContext _db;

    public UserRepository(PaletteDbContext db) => _db = db;

    public async Task<Guid?> GetIdByGoogleSubAsync(string? googleSub, CancellationToken cancellationToken)
    {
        var userId = await _db.Users.Where(u => u.GoogleSubjectId == googleSub).Select(u => u.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return userId;
    }
}