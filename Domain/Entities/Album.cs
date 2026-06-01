namespace Domain.Entities;

public class Album
{
    public int AlbumId { get; set; }
    public required string AlbumName { get; set; }
    public required string ArtistName { get; set; }
    public required string ImageUrl { get; set; }
    public string? SpotifyUrl { get; set; }
    public string? QobuzUrl { get; set; }
    
    public ICollection<AlbumListMapping> AlbumListMappings { get; set; } = new List<AlbumListMapping>();

}