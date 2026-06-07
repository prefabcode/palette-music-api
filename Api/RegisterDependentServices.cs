// RegisterDependentServices.cs

using Application.Interfaces;
using Application.UseCases;
using Asp.Versioning;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

public static class RegisterDependentServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {

        var config = builder.Configuration;
        
        config.AddYamlFile("appsettings.yml", optional: false, reloadOnChange: true);
        config.AddYamlFile($"appsettings.{builder.Environment.EnvironmentName}.yml", optional: true, reloadOnChange: true);
        
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<PaletteDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://accounts.google.com";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://accounts.google.com",
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Google:ClientId"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
       
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Components ??= new();
                document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
                document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Paste your Google ID token here"
                };
                return Task.CompletedTask;
            });
        });
       
        builder.Services.AddScoped<IUserProvisioningService, UserProvisioningService>();
        builder.Services.AddScoped<IAlbumListRepository, AlbumListRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<GetAlbumListsUseCase>();
        builder.Services.AddScoped<GetUserInfoUseCase>();
        builder.Services.AddScoped<GetSluggedAlbumListUseCase>();
        
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        
        // future: DbContext, repositories, etc.
        
        return builder;
    }
}