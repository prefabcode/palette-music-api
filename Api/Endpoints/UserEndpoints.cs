using System.Security.Claims;
using Application.UseCases;

namespace Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("user/me", GetUserInfo);
    }

    public static async Task<IResult> GetUserInfo(
        ClaimsPrincipal principal, 
        GetUserInfoUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.ExecuteAsync(principal, cancellationToken);
        return Results.Ok(result);
    }
}