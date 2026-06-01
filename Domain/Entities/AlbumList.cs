namespace Domain.Entities;

public class AlbumList
{
    public int Id { get; set; }
    public required string ListName { get; set; }
    public required string Slug { get; set; }
    
    public ICollection<AlbumListMapping> AlbumListMappings { get; set; } = new List<AlbumListMapping>();

}