namespace Domain.Entities;

public class Album
{
    public int AlbumId { get; set; }
    public string AlbumName { get; set; }
    public string ArtistName { get; set; }
    public string ImageUrl { get; set; }
    public string SpotifyUrl { get; set; }
    
    public ICollection<AlbumListMapping> AlbumListMappings { get; set; } = new List<AlbumListMapping>();

}