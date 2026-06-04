namespace Api.Endpoints;

public static class AlbumEndpoints
{
    public static void MapAlbumEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("albums/{id:int}/favorite", AddFavoriteAlbum);
        endpoints.MapDelete("albums/{id:int}/favorite", DeleteFavoriteAlbum);
        endpoints.MapPut("albums/{id:int}/listened", AddListenedAlbum);
        endpoints.MapDelete("albums/{id:int}/listened", DeleteListenedAlbum);
    }

    public static async Task<IResult> AddFavoriteAlbum(int id)
    {
        throw new NotImplementedException();
    }

    public static async Task<IResult> DeleteFavoriteAlbum(int id)
    {
        throw new NotImplementedException();
    }

    public static async Task<IResult> AddListenedAlbum(int id)
    {
        throw new NotImplementedException();
    }

    public static async Task<IResult> DeleteListenedAlbum(int id)
    {
        throw new NotImplementedException();
    }
}