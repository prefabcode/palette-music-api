namespace Application.ResponseModels;

public class SluggedAlbumListResponse
{
    public string? ListName { get; set; }
    
    public required string Slug { get; set; }
    
    public List<UserAlbumResponse> UserAlbums { get; set; } = new List<UserAlbumResponse>();
    
}