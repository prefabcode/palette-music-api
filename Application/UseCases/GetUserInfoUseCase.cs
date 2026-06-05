using System.Security.Claims;
using Application.Interfaces;
using Application.ResponseModels;

namespace Application.UseCases;

public class GetUserInfoUseCase
{
    private readonly IUserProvisioningService _userProvisioningService;
    
    public GetUserInfoUseCase(IUserProvisioningService userProvisioningService) 
        => _userProvisioningService = userProvisioningService;

    public async Task<UserResponse> ExecuteAsync(ClaimsPrincipal principal, CancellationToken cancellationToken)
    {
        var user = await _userProvisioningService.EnsureUserAsync(principal, cancellationToken);

        return new UserResponse()
        {
            Email = user.Email,
            PreferredStreamer = user.PreferredStreamer?.ToString()
        };
    }
}