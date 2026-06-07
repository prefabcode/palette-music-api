using System.Security.Claims;
using Application.Interfaces;
using Application.ResponseModels;

namespace Application.UseCases;

public class GetSluggedAlbumListUseCase
{
    private readonly IAlbumListRepository _albumListRepository;
    private readonly IUserRepository _userRepository;

    public GetSluggedAlbumListUseCase(IAlbumListRepository albumListRepository, IUserRepository userRepository)
    {
        _albumListRepository = albumListRepository;
        _userRepository = userRepository;
    }

    public async Task<SluggedAlbumListResponse?> ExecuteAsync(ClaimsPrincipal principal, string slug, CancellationToken cancellationToken)
    {
        var googleSub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var userId = await _userRepository.GetIdByGoogleSubAsync(googleSub, cancellationToken);

        if (userId == null)
        {
            return null;
        }
        
        return await _albumListRepository.GetBySlugAsync(userId.Value, slug, cancellationToken);
    }

}