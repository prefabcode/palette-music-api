using System.Security.Claims;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserProvisioningService
{
    Task<User> EnsureUserAsync(ClaimsPrincipal principal);
}