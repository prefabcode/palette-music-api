// See https://aka.ms/new-console-template for more information

var app = WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build();
    
    app.SetupMiddleware()
        .Run();
        