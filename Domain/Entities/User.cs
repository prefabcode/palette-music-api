namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public DateTime DateCreated { get; set; }

    public ICollection<UserListenedAlbum> ListenedAlbums { get; set; } = new List<UserListenedAlbum>();
}