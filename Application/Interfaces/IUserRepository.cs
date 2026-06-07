namespace Application.Interfaces;

public interface IUserRepository
{
    Task<Guid?> GetIdByGoogleSubAsync(string? googleSub, CancellationToken cancellationToken);
}