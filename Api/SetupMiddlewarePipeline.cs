// SetupMiddlewarePipeline.cs

using Api.Endpoints;
using Asp.Versioning;
using Scalar.AspNetCore;

public static class SetupMiddlewarePipeline
{
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi(); 
            app.MapScalarApiReference();   
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        var apiVersionSet = app.NewApiVersionSet().HasApiVersion(new ApiVersion(1)).ReportApiVersions().Build();
        RouteGroupBuilder versionedGroup = app.MapGroup("api/v{version:apiVersion}")
            .WithApiVersionSet(apiVersionSet)
            .RequireAuthorization();
        
        versionedGroup.MapAlbumListEndpoints();
        versionedGroup.MapAlbumEndpoints();
        versionedGroup.MapUserEndpoints();

        return app;
    }
}