using System.Security.Claims;
using Application.Interfaces;

namespace Application.UseCases;

public class AddListenedAlbumUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserLibraryRepository _userLibraryRepository;

    public AddListenedAlbumUseCase(IUserRepository userRepository, IUserLibraryRepository userLibraryRepository)
    {
        _userRepository = userRepository;
        _userLibraryRepository = userLibraryRepository;
    }
    
    public async Task ExecuteAsync(ClaimsPrincipal principal, int albumId, CancellationToken cancellationToken)
    {
        var googleSub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var userId = await _userRepository.GetIdByGoogleSubAsync(googleSub, cancellationToken);

        if (userId != null)
        {
            await _userLibraryRepository.AddListenedAlbumAsync(userId.Value, albumId, cancellationToken);
        }
    }
}