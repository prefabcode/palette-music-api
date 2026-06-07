using System.Security.Claims;
using Application.ResponseModels;
using Application.UseCases;

namespace Api.Endpoints;

public static class AlbumListEndpoints
{
    public static void MapAlbumListEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("albumlists", GetAlbumLists);
        endpoints.MapGet("albumlists/{slug}", GetAlbumListBySlug);
    }
    
    public static async Task<IResult> GetAlbumLists(
        GetAlbumListsUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.ExecuteAsync(cancellationToken);
        return Results.Ok(result);
    }

    public static async Task<IResult> GetAlbumListBySlug(
        ClaimsPrincipal principal, 
        GetSluggedAlbumListUseCase useCase,
        string slug, 
        CancellationToken cancellationToken)
    {
        var result = await useCase.ExecuteAsync(principal, slug, cancellationToken);
        if (result is null)
            return Results.NotFound();
        
        return Results.Ok(result);
    }

    
}