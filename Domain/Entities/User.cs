using Domain.Enums;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? GoogleSubjectId { get; set; }
    public required string Email { get; set; }
    public DateTime DateCreated { get; set; }
    public StreamingService? PreferredStreamer { get; set; }

    public ICollection<UserListenedAlbum> ListenedAlbums { get; set; } = new List<UserListenedAlbum>();
}