// RegisterDependentServices.cs

using Infrastructure;
using Microsoft.EntityFrameworkCore;

public static class RegisterDependentServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<PaletteDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // future: DbContext, repositories, etc.
        
        return builder;
    }
}