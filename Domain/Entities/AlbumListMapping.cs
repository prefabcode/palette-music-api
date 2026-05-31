namespace Domain.Entities;

public class AlbumListMapping
{
    public int Id { get; set; }

    public int AlbumId { get; set; }
    public Album Album { get; set; }          // navigation to the album

    public Guid AlbumListId { get; set; }
    public AlbumList AlbumList { get; set; }   // navigation to the list
}