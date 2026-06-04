using Application.Interfaces;
using Application.ResponseModels;
using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases;

public class GetAlbumListsUseCase
{
    private readonly IAlbumListRepository _repository;

    public GetAlbumListsUseCase(IAlbumListRepository repository)
        => _repository = repository;

    public async Task<Dictionary<string, List<AlbumListResponse>>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var lists = await _repository.GetAllAsync(cancellationToken);
        
        return lists
            .GroupBy(l => l.ListType.ToString())
            .ToDictionary(
                g => g.Key,
                g => g.Select(list => new AlbumListResponse
                {
                    ListName = list.ListName,
                    Slug = list.Slug,
                }).ToList()  
            );
    }
}