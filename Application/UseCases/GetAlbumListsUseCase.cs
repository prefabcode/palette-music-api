using Application.Interfaces;
using Application.ResponseModels;

namespace Application.UseCases;

public class GetAlbumListsUseCase
{
    private readonly IAlbumListRepository _repository;

    public GetAlbumListsUseCase(IAlbumListRepository repository)
        => _repository = repository;

    public async Task<List<AlbumListResponse>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var lists = await _repository.GetAllAsync(cancellationToken);

        return lists.Select(list => new AlbumListResponse
        {
            ListName = list.ListName,
            Slug = list.Slug,
            ListType = list.ListType.ToString()
        }).ToList();
    }
}