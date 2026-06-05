namespace Application.ResponseModels;

public class UserResponse
{
    public required string Email { get; set; }
    public string? PreferredStreamer { get; set; }
}