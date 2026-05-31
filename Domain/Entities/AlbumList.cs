namespace Domain.Entities;

public class AlbumList
{
    public Guid Id { get; set; }
    public string ListName { get; set; }
    
    public ICollection<AlbumListMapping> AlbumListMappings { get; set; } = new List<AlbumListMapping>();

}