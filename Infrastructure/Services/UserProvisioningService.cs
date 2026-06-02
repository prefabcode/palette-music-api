using System.Security.Claims;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserProvisioningService : IUserProvisioningService
{
    private readonly PaletteDbContext _db;

    public UserProvisioningService(PaletteDbContext db) => _db = db;

    public async Task<User> EnsureUserAsync(ClaimsPrincipal principal)
    {
        var googleSub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = principal.FindFirst(ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(googleSub))
            throw new InvalidOperationException("No subject claim on token.");

        var user = await _db.Users
            .FirstOrDefaultAsync(u => u.GoogleSubjectId == googleSub);

        if (user is null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                GoogleSubjectId = googleSub,
                Email = email ?? string.Empty,
                DateCreated = DateTime.UtcNow
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        return user;
    }

}