// RegisterDependentServices.cs
public static class RegisterDependentServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // future: DbContext, repositories, etc.
        
        return builder;
    }
}