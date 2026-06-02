namespace Api.Endpoints;

public static class AlbumListEndpoints
{
    public static void MapAlbumListEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("albumlists/{slug}", GetAlbumListBySlug);
    }

    public static async Task<IResult> GetAlbumListBySlug(string slug)
    {
        throw new NotImplementedException();
    }
}