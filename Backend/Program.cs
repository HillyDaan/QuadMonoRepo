var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",
                "https://quadmonorepo-frontend-production.up.railway.app"
              )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<ITriviaApiService, TriviaApiService>();
builder.Services.AddScoped<ITriviaService, TriviaService>();
builder.Services.AddSingleton<IStorageProvider, InMemoryStorageProvider>();
builder.Services.AddScoped<ITriviaStorageService, TriviaStorageService>();


var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();
app.Run();