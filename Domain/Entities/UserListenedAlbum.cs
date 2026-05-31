namespace Domain.Entities;

public class UserListenedAlbum
{
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public int AlbumId { get; set; }
    public Album Album { get; set; }

    public DateTime ListenedAt { get; set; }
}