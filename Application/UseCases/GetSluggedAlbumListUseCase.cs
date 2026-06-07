using System.Security.Claims;
using Application.Interfaces;
using Application.ResponseModels;

namespace Application.UseCases;

public class GetSluggedAlbumListUseCase
{
    private readonly IAlbumListRepository _repository;
    private readonly IUserProvisioningService _userProvisioningService;

    public GetSluggedAlbumListUseCase(IAlbumListRepository repository, IUserProvisioningService userProvisioningService)
    {
        _repository = repository;
        _userProvisioningService = userProvisioningService;
    }

    public async Task<SluggedAlbumListResponse?> ExecuteAsync(ClaimsPrincipal principal, string slug, CancellationToken cancellationToken)
    {
        var user = await _userProvisioningService.EnsureUserAsync(principal, cancellationToken);
        
        // TODO: ERROR CHECKING HERE IF USER DOESN'T EXIST? 
        
        return await _repository.GetBySlugAsync(user.Id, slug, cancellationToken);
    }

}