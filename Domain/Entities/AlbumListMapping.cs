namespace Domain.Entities;

public class AlbumListMapping
{
    public int Id { get; set; }

    public int AlbumId { get; set; }
    public Album Album { get; set; }     

    public int AlbumListId { get; set; }
    public AlbumList AlbumList { get; set; }   
}