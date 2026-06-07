namespace Application.ResponseModels;

public class UserAlbumResponse
{
    public int AlbumId { get; set; }
    public required string AlbumName { get; set; }
    public required string ArtistName { get; set; }
    public required string ImageUrl { get; set; }
    public string? SpotifyUrl { get; set; }
    public string? QobuzUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? AppleMusicUrl { get; set; }
    public string? SoundCloudUrl { get; set; }
    public string? TidalUrl { get; set; }
    public string? DeezerUrl { get; set; }
    public bool HasListened { get; set; }
    public bool HasFavorited { get; set; }
}