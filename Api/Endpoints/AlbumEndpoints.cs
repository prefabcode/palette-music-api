using System.Security.Claims;
using Application.UseCases;

namespace Api.Endpoints;

public static class AlbumEndpoints
{
    public static void MapAlbumEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("albums/{albumId:int}/favorite", AddFavoriteAlbum);
        endpoints.MapDelete("albums/{albumId:int}/favorite", RemoveFavoriteAlbum);
        endpoints.MapPut("albums/{albumId:int}/listened", AddListenedAlbum);
        endpoints.MapDelete("albums/{albumId:int}/listened", RemoveListenedAlbum);
    }

    public static async Task<IResult> AddFavoriteAlbum(
        AddFavoriteAlbumUseCase useCase,
        ClaimsPrincipal principal, 
        int albumId, 
        CancellationToken cancellationToken)
    {
        await useCase.ExecuteAsync(principal, albumId, cancellationToken);
        return Results.NoContent();
    }

    public static async Task<IResult> RemoveFavoriteAlbum(
        RemoveFavoriteAlbumUseCase useCase, 
        ClaimsPrincipal principal, 
        int albumId,
        CancellationToken cancellationToken)
    {
        await useCase.ExecuteAsync(principal, albumId, cancellationToken);
        return Results.NoContent();
    }

    public static async Task<IResult> AddListenedAlbum(
        AddListenedAlbumUseCase useCase,
        ClaimsPrincipal principal,
        int albumId,
        CancellationToken cancellationToken
        )
    {
        await useCase.ExecuteAsync(principal, albumId, cancellationToken);
        return Results.NoContent();
    }

    public static async Task<IResult> RemoveListenedAlbum(
        RemoveListenedAlbumUseCase useCase,
        ClaimsPrincipal principal,
        int albumId,
        CancellationToken cancellationToken)
    {
        await useCase.ExecuteAsync(principal, albumId, cancellationToken);
        return Results.NoContent();
    }
}